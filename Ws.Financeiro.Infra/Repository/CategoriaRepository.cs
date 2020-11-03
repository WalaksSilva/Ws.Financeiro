using Microsoft.EntityFrameworkCore;
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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EntityContext context) : base(context)
        {

        }

        public async Task<Categoria> ObterPorId(int id)
        {
            return await Db.Categorias.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ObterTodosPorUsuario(int idUsuario)
        {
            return await Db.Categorias.AsNoTracking().Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<Categoria> ObterPorIdEndUsuario(int id, int idUsuario)
        {
            return await Db.Categorias.AsNoTracking().Where(x => x.IdUsuario == idUsuario && x.Id == id).FirstOrDefaultAsync();
        }
    }
}
