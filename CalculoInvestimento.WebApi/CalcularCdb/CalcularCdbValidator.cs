using FluentValidation;

namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class CalcularCdbValidator : AbstractValidator<CalcularCdbCommand>
    {
        public CalcularCdbValidator()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("Valor deve ser positivo");

            RuleFor(x => x.PrazoMeses)
                .GreaterThan(1)
                .WithMessage("Período deve ser maior que 1 mês");
        }
    }
}
