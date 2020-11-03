using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> ObterPorId(int id);
        Task<Categoria> ObterPorIdEndUsuario(int id, int idUsuario);
        Task<IEnumerable<Categoria>> ObterTodosPorUsuario(int idUsuario);
    }
}
