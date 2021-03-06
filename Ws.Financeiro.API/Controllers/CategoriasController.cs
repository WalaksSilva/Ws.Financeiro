﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(
                                    ICategoriaRepository categoriaRepository, 
                                    ICategoriaService categoriaService, 
                                    IMapper mapper,
                                    INotificador notificador,
                                    IUser user) : base(notificador, user)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodosPorUsuario(UsuarioId));
        }

        [HttpPost("")]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);

            categoria.IdUsuario = UsuarioId;

            await _categoriaService.Adicionar(categoria);

            return CustomResponse(categoriaViewModel);
        }
            
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(int id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var categoriaViewModelRetorno = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorIdEndUsuario(id, UsuarioId));
            if (categoriaViewModelRetorno == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Atualizar(categoria);

            return CustomResponse(categoriaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(int id)
        {
            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorIdEndUsuario(id, UsuarioId));

            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            await _categoriaService.Remover(id);

            return CustomResponse();


        }
    }
}
