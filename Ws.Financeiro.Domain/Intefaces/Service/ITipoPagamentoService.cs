using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Service
{
    public interface ITipoPagamentoService : IDisposable
    {
        Task<bool> Adicionar(TipoPagamento tipoPagamento);
        Task<bool> Atualizar(TipoPagamento tipoPagamento);
        Task<bool> Remover(int id);
    }
}
