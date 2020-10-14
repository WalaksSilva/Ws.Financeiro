using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Models;

namespace Ws.Financeiro.Domain.Intefaces.Service
{
    public interface ICategoriaService : IDisposable
    {
        Task<bool> Adicionar(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Remover(int id);
    }
}
