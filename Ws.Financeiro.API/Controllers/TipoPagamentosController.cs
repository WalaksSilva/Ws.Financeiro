using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentosController : MainController
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;
        private readonly ITipoPagamentoService _tipoPagamentoService;
        private readonly IMapper _mapper;

        public TipoPagamentosController(
                                    ITipoPagamentoRepository tipoPagamentoRepository,
                                    ITipoPagamentoService tipoPagamentoService, 
                                    IMapper mapper,
                                    INotificador notificador,
                                    IUser user) : base(notificador, user)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
            _tipoPagamentoService = tipoPagamentoService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IEnumerable<TipoPagamentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TipoPagamentoViewModel>>(await _tipoPagamentoRepository.ObterTodos());
        }

        [HttpPost("")]
        public async Task<ActionResult<TipoPagamentoViewModel>> Adicionar(TipoPagamentoViewModel tipoPagamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var tipoPagamento = _mapper.Map<TipoPagamento>(tipoPagamentoViewModel);
            await _tipoPagamentoService.Adicionar(tipoPagamento);

            return CustomResponse(tipoPagamentoViewModel);
        }
            
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TipoPagamentoViewModel>> Atualizar(int id, TipoPagamentoViewModel tipoPagamentoViewModel)
        {
            if (id != tipoPagamentoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var tipoPagamento = _mapper.Map<TipoPagamento>(tipoPagamentoViewModel);
            await _tipoPagamentoService.Atualizar(tipoPagamento);

            return CustomResponse(tipoPagamento);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TipoPagamentoViewModel>> Excluir(int id)
        {
            var tipoPagamentoViewModel = _mapper.Map<TipoPagamentoViewModel>(await _tipoPagamentoRepository.ObterPorId(id));

            if (tipoPagamentoViewModel == null)
            {
                return NotFound();
            }

            await _tipoPagamentoService.Remover(id);

            return CustomResponse();


        }
    }
}
