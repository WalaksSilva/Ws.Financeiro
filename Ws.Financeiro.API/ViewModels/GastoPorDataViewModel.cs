using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.API.ViewModels
{
    public class GastoPorDataViewModel
    {
        public GastoPorDataViewModel(string data, IEnumerable<GastoViewModel> gastos) {
            Data = data;
            Gastos = gastos;
        }

        public string Data { get; set; }
        public IEnumerable<GastoViewModel> Gastos { get; set; }
    }
}
