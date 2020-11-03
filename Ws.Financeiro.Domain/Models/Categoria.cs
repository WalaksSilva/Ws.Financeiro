using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Ws.Financeiro.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Gasto> Gastos { get; set; }
        public int IdUsuario { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
