using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;
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
                var calcularInvestimentoCdb = scope.ServiceProvider.GetRequiredService<ICalcularInvestimentoCdb>();
                return await calcularInvestimentoCdb.Calcular(valor, prazoMeses);
            // Adicionar outros tipos aqui
            default:
                throw new NotImplementedException();
        }
    }
}