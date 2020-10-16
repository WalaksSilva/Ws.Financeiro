using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Domain.Models;
using Ws.Financeiro.Domain.Services;

namespace Ws.Financeiro.API.Controllers
{
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
                                    INotificador notificador) : base(notificador
                                        
                                    )
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }

        [HttpPost("")]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
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

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaService.Atualizar(categoria);

            return CustomResponse(categoriaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(int id)
        {
            var categoriaViewModel = _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));

            if (categoriaViewModel == null)
            {
                return NotFound();
            }

            await _categoriaService.Remover(id);

            return CustomResponse();


        }
    }
}
