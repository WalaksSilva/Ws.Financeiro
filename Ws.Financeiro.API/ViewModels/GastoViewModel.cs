using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws.Financeiro.API.ViewModels
{
    public class GastoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
        public DateTime Data { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdTipoPagamento { get; set; }
        public string TipoPagamento { get; set; }
        public int IdUsuario { get; set; }
    }
}
