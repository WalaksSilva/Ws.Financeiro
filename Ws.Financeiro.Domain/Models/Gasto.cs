using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class Gasto : Entity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
