using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class GastoPorData
    {
        public string Data { get; set; }
        public IEnumerable<Gasto> Gastos { get; set; }
    }
}
