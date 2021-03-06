﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<Gasto> ObterPorIdEndUsuario(int id, int idUsuario)
        {
            return await Db.Gastos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id && c.IdUsuario == idUsuario);
        }

        public async Task<IEnumerable<Gasto>> ObterGastosPorUsuarioAsync(int idUsuario)
        {
            return await Db.Gastos.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<IEnumerable<Gasto>> Filtro(GastoFiltro gastoFiltro)
        {
            var query = Db.Gastos.Where(x => x.IdUsuario == gastoFiltro.IdUsuario).AsNoTracking();

            
            if (gastoFiltro.IdCategoria > 0)
            {
                query = query.Where(x => x.IdCategoria == gastoFiltro.IdCategoria);    
            }

            if (gastoFiltro.IdTipoPagamento > 0)
            {
                query = query.Where(x => x.IdTipoPagamento == gastoFiltro.IdTipoPagamento);
            }

            if (gastoFiltro.DataInicio != null && gastoFiltro.DataFim != null)
            {
                //var dataFim = gastoFiltro.DataFim.Value.AddDays(1);
                query = query.Where(x => x.IdUsuario == gastoFiltro.IdUsuario && x.Data >= gastoFiltro.DataInicio && x.Data <= gastoFiltro.DataFim.Value.AddDays(1));
            }

            var gastos = await query.ToListAsync();

            return gastos;
        }
    }
}
