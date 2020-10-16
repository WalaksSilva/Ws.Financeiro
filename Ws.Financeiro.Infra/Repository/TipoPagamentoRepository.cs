using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Models;
using Ws.Financeiro.Infra.Context;

namespace Ws.Financeiro.Infra.Repository
{
    public class TipoPagamentoRepository : Repository<TipoPagamento>, ITipoPagamentoRepository
    {
        public TipoPagamentoRepository(EntityContext context) : base(context)
        {

        }

        public async Task<TipoPagamento> ObterPorId(int id)
        {
            return await Db.TipoPagamento.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
