﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ws.Financeiro.API.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<GastoViewModel> Gastos { get; set; }
        public int IdUsuario { get; set; }
    }
}
