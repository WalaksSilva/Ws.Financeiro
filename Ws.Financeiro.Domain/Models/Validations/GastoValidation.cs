using FluentValidation;

namespace Ws.Financeiro.Domain.Models.Validations
{
    public class GastoValidation : AbstractValidator<Gasto>
    {
        public GastoValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
