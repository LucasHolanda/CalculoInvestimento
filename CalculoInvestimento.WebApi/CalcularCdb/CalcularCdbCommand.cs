using MediatR;

namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class CalcularCdbCommand : IRequest<InvestimentoCdbDto>
    {
        public decimal Valor { get; set; }
        public int PrazoMeses { get; set; }
    }
}
