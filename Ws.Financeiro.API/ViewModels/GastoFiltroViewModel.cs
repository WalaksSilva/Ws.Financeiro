using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws.Financeiro.API.ViewModels
{
    public class GastoFiltroViewModel
    {
        public int IdCategoria { get; set; }
        public int IdTipoPagamento { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
