using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Gasto> Gastos { get; set; }
    }
}
