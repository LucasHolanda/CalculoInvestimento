using CalculoInvestimento.Domain.Entities;

namespace CalculoInvestimento.Domain.Service
{
    public interface ICalcularCdbService
    {
        Task<InvestimentoCdb?> CalcularAsync(decimal valor, int prazoMeses);
    }
}
