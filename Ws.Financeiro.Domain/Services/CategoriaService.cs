using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ws.Financeiro.Domain.Intefaces;
using Ws.Financeiro.Domain.Intefaces.Repository;
using Ws.Financeiro.Domain.Intefaces.Service;
using Ws.Financeiro.Domain.Models;
using Ws.Financeiro.Domain.Models.Validations;

namespace Ws.Financeiro.Domain.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        //CRUD
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            if (_categoriaRepository.Buscar(f => f.Nome == categoria.Nome).Result.Any())
            {
                Notificar("Já existe um categria com esse nome.");
                return false;
            }

            await _categoriaRepository.Adicionar(categoria);
            return true;
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return false;

            if (_categoriaRepository.Buscar(f => f.Nome == categoria.Nome).Result.Any())
            {
                Notificar("Já existe um categria com esse nome.");
                return false;
            }

            await _categoriaRepository.Atualizar(categoria);
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _categoriaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
