using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Repository
{
    public interface IGastoRepository : IRepository<Gasto>
    {
        Task<Gasto> ObterGastoData(DateTime data);
        Task<Gasto> ObterPorId(int id);
        Task<IEnumerable<Gasto>> Filtro(GastoFiltro gastoFiltro);
        Task<IEnumerable<Gasto>> ObterGastosPorUsuarioAsync(int idUsuario);
    }
}
