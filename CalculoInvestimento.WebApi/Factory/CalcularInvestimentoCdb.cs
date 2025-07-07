using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;

namespace CalculoInvestimento.WebApi.Factory
{
    public class CalcularInvestimentoCdb: ICalcularInvestimentoCdb
    {
        private readonly ICalcularCdbStrategy _calcularCdbStrategy;
        private readonly ICdbTaxaProvider _cdbTaxaProvider;

        public CalcularInvestimentoCdb(ICalcularCdbStrategy calcularCdbStrategy, ICdbTaxaProvider cdbTaxaProvider)
        {
            _calcularCdbStrategy = calcularCdbStrategy;
            _cdbTaxaProvider = cdbTaxaProvider;
        }

        public async Task<IInvestimento> Calcular(decimal valor, int prazoMeses)
        {
            var (tb, cdi) = await _cdbTaxaProvider.ObterTaxasAsync();
            return new InvestimentoCdb(valor, prazoMeses, tb, cdi, _calcularCdbStrategy);
        }
    }
}
