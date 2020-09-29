using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Domain.Models;
using Ws.Financeiro.Domain.Models.Validations;

namespace Ws.Financeiro.Domain.Services
{
    public class GastoService : BaseService, IGastoService
    {
        private readonly IGastoRepository _gastoRepository;

        public GastoService(IGastoRepository gastoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<bool> Adicionar(Gasto gasto)
        {
            if (!ExecutarValidacao(new GastoValidation(), gasto)) return false;

            if (_gastoRepository.Buscar(f => f.Id == gasto.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _gastoRepository.Adicionar(gasto);
            return true;
        }

        public async Task<bool> Atualizar(Gasto gasto)
        {
            if (!ExecutarValidacao(new GastoValidation(), gasto)) return false;

            await _gastoRepository.Atualizar(gasto);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _gastoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _gastoRepository?.Dispose();
        }
    }
}
