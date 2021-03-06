﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Service
{
    public interface IGastoService : IDisposable
    {
        Task<bool> Adicionar(Gasto gasto);
        Task<bool> Atualizar(Gasto gasto);
        Task<bool> Remover(int id);
        Task<IEnumerable<GastoPorData>> ObterGastosAgrupadosPorData(int idUsuario);

    }
}
