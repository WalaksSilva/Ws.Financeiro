using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.Financeiro.Domain.Models.Validations
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
