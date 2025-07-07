using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.Factory;

public class InvestimentoFactory : IInvestimentoFactory
{
    private readonly IServiceScopeFactory _scopeFactory;

    public InvestimentoFactory(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<IInvestimento> Criar(TipoInvestimento tipo, decimal valor, int prazoMeses)
    {
        using var scope = _scopeFactory.CreateScope();

        switch (tipo)
        {
            case TipoInvestimento.Cdb:
                var impostoStrategy = scope.ServiceProvider.GetRequiredService<IImpostoStrategy>();
                var calculoCdbStrategy = scope.ServiceProvider.GetRequiredService<ICalcularCdbStrategy>();
                var cdbTaxaProvider = scope.ServiceProvider.GetRequiredService<ICdbTaxaProvider>();

                var (tb, cdi) = await cdbTaxaProvider.ObterTaxasAsync();
                return new InvestimentoCdb(valor, prazoMeses, tb, cdi, impostoStrategy, calculoCdbStrategy);
            // Adicionar outros tipos aqui, resolvendo suas estratégias específicas
            default:
                throw new NotImplementedException();
        }
    }
}