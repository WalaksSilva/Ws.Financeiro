using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models
{
    public class GastoFiltro
    {
        public int IdCategoria { get; set; }
        public int IdTipoPagamento { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int IdUsuario { get; set; }
    }
}
