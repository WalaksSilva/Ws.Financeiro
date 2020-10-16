﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Models;
using Ws.Financeiro.Infra.Context;

namespace Ws.Financeiro.Infra.Repository
{
    public class GastoRepository : Repository<Gasto>, IGastoRepository
    {
        public GastoRepository(EntityContext context) : base(context)
        {
        }

        public async Task<Gasto> ObterGastoData(DateTime data)
        {
            return await Db.Gastos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Data == data);
        }

        public async Task<Gasto> ObterPorId(int id)
        {
            return await Db.Gastos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
