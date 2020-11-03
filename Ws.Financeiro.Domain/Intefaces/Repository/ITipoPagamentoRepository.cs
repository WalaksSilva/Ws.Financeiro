using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Repository
{
    public interface ITipoPagamentoRepository : IRepository<TipoPagamento>
    {
        Task<IEnumerable<TipoPagamento>> ObterTodosPorUsuario(int idUsuario);

        Task<TipoPagamento> ObterTodosPorIdEndUsuario(int id, int idUsuario);
    }
}
