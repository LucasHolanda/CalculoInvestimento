using CalculoInvestimento.Domain.Entities;

namespace CalculoInvestimento.WebApi.Factory
{
    public interface ICalcularInvestimentoCdb
    {
        Task<IInvestimento> Calcular(decimal valor, int prazoMeses);
    }
}
