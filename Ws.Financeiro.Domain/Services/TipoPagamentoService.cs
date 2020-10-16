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
    public class TipoPagamentoService : BaseService, ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;

        public TipoPagamentoService(ITipoPagamentoRepository tipoPagamentoRepository,
                                    INotificador notificador) : base(notificador
                                    )
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }

        public async Task<bool> Adicionar(TipoPagamento tipoPagamento)
        {
            if (!ExecutarValidacao(new TipoPagamentoValidation(), tipoPagamento)) return false;

            if (_tipoPagamentoRepository.Buscar(f => f.Nome == tipoPagamento.Nome).Result.Any())
            {
                Notificar("Já existe um tipo de pagamento com esse nome.");
                return false;
            }

            await _tipoPagamentoRepository.Adicionar(tipoPagamento);
            return true;
        }

        public async Task<bool> Atualizar(TipoPagamento tipoPagamento)
        {
            if (!ExecutarValidacao(new TipoPagamentoValidation(), tipoPagamento)) return false;

            if (_tipoPagamentoRepository.Buscar(f => f.Nome == tipoPagamento.Nome).Result.Any())
            {
                Notificar("Já existe um tipo de pagamento com esse nome.");
                return false;
            }

            await _tipoPagamentoRepository.Atualizar(tipoPagamento);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _tipoPagamentoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _tipoPagamentoRepository?.Dispose();
        }
    }
}
