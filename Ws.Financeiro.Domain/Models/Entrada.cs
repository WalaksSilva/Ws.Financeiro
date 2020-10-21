using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class Entrada : Entity
    {
        public DateTime Data { get; set; }
        public DateTime DataFaturamento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Origem { get; set; }
    }
}
