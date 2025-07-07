using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.WebApi.Factory;

namespace CalculoInvestimento.WebApi.Service
{
    public class CalcularCdbService : ICalcularCdbService
    {
        private readonly IInvestimentoFactory _factory;

        public CalcularCdbService(IInvestimentoFactory factory)
        {
            _factory = factory;
        }

        public async Task<InvestimentoCdb?> CalcularAsync(decimal valor, int prazoMeses)
        {            
            var investimento = (InvestimentoCdb) await _factory.Criar(TipoInvestimento.Cdb, valor, prazoMeses);
            await investimento.CalcularCDBAsync();
            return investimento;
        }
    }
}
