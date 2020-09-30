using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class TipoPagamento : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Gasto> Gastos { get; set; }
    }
}
