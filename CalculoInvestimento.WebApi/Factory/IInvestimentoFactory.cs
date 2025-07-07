using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;

namespace CalculoInvestimento.WebApi.Factory
{
    public interface IInvestimentoFactory
    {
        Task<IInvestimento> Criar(TipoInvestimento tipo, decimal valor, int prazoMeses);
    }
}
