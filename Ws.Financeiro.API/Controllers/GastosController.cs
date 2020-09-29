using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws.Financeiro.API.ViewModels;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Infra.Repository;

namespace Ws.Financeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IGastoService _gastoService;
        private readonly IMapper _mapper;
        public GastosController(
            IGastoRepository gastoRepository,
            IGastoService gastoService,
            IMapper mapper
            )
        {
            _gastoRepository = gastoRepository;
            _gastoService = gastoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastoViewModel>>> ObeterTodos()
        {
            var gastos = _mapper.Map<IEnumerable<GastoViewModel>>(await _gastoRepository.ObterTodos());
            return Ok(gastos);
        }
    }
}
