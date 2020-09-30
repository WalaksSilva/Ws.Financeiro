using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class Gasto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdTipoPagamento { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
    }
}
