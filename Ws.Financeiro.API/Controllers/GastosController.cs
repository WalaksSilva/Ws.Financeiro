using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : MainController
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IGastoService _gastoService;
        private readonly IMapper _mapper;
        public GastosController(
                                IGastoRepository gastoRepository,
                                IGastoService gastoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador
                                )
        {
            _gastoRepository = gastoRepository;
            _gastoService = gastoService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<GastoViewModel>>> ObeterTodos()
        {
            var gastos = _mapper.Map<IEnumerable<GastoViewModel>>(await _gastoRepository.ObterTodos());
            return CustomResponse(gastos);
        }

        [HttpPost("")]
        public async Task<ActionResult<GastoViewModel>> Adicionar(GastoViewModel gastoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var gasto = _mapper.Map<Gasto>(gastoViewModel);
            await _gastoService.Adicionar(gasto);

            return CustomResponse(gastoViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GastoViewModel>> Atualizar(int id, GastoViewModel gastoViewModel)
        {
            if (id != gastoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var gasto = _mapper.Map<Gasto>(gastoViewModel);
            await _gastoService.Atualizar(gasto);

            return CustomResponse(gastoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GastoViewModel>> Excluir(int id)
        {
            var gastoViewModel = _mapper.Map<GastoViewModel>(await _gastoRepository.ObterPorId(id));

            if (gastoViewModel == null) return NotFound();

            await _gastoService.Remover(id);

            return CustomResponse(gastoViewModel);
        }

        [HttpGet("gastos-por-data")]
        public async Task<ActionResult<IEnumerable<GastoPorDataViewModel>>> ObterGastosAgrupadosPorData()
        {
            var gastosPorData = await _gastoService.ObterGastosAgrupadosPorData();
            var gastosPrDataViewModel = gastosPorData.Select(x => new GastoPorDataViewModel(x.Data, _mapper.Map<IEnumerable<GastoViewModel>>(x.Gastos))).ToList();

            return CustomResponse(gastosPrDataViewModel);
        }

        [HttpPost("filtrado")]
        public async Task<ActionResult<IEnumerable<GastoViewModel>>> Filtro(GastoFiltroViewModel filtroViewModel)
        {
            var filtro = _mapper.Map<GastoFiltro>(filtroViewModel);
            var gastosViewModel = _mapper.Map<IEnumerable<GastoViewModel>>(await _gastoRepository.Filtro(filtro));
            return CustomResponse(gastosViewModel);
        }
    }
}
