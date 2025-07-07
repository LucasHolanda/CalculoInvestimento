using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.Factory;
using CalculoInvestimento.WebApi.Service;
using FluentAssertions;
using NSubstitute;

public class CalcularCdbServiceTests
{
    private readonly IInvestimentoFactory investimentoFactory;
    private readonly ICalcularCdbStrategy calcularCdbStrategy;
    const decimal TB = 1.08m;
    const decimal CDI = 0.009m;

    public CalcularCdbServiceTests()
    {
        investimentoFactory = Substitute.For<IInvestimentoFactory>();
        calcularCdbStrategy = new CalcularCdbStrategy();
    }

    [Fact(DisplayName = "Service deve calcular corretamente o valor bruto e líquido do CDB")]
    public async Task Service_DeveCalcularCorretamenteValoresBrutoELiquido()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 12;

        var investimentoResult = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);
        investimentoFactory.Criar(TipoInvestimento.Cdb, valorInicial, prazoMeses).Returns(investimentoResult);
        var service = new CalcularCdbService(investimentoFactory);
        investimentoResult.Calcular();

        // When
        var investimento = await service.CalcularAsync(valorInicial, prazoMeses);

        // Then
        investimento.Should().NotBeNull();

        investimento.ValorInicial.Should().Be(investimentoResult.ValorInicial);
        investimento.PrazoMeses.Should().Be(investimentoResult.PrazoMeses);

        investimento.ValorBruto.Should().Be(investimentoResult.ValorBruto);
        investimento.ValorLiquido.Should().Be(investimentoResult.ValorLiquido);
        await investimentoFactory.Received(1).Criar(TipoInvestimento.Cdb, valorInicial, prazoMeses);
    }
}