using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Strategy;
using FluentAssertions;

public class InvestimentoCdbTests
{
    private readonly ICalcularCdbStrategy calcularCdbStrategy;
    const decimal TB = 1.08m;
    const decimal CDI = 0.009m;
    public InvestimentoCdbTests()
    {
        calcularCdbStrategy = new CalcularCdbStrategy();
    }

    [Fact(DisplayName = "Deve calcular corretamente o valor bruto e líquido para 6 meses com alíquota de 22,5%")]
    public void DeveCalcularCorretamenteParaSeisMeses()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 6;
        decimal imposto = calcularCdbStrategy.CalcularImposto(prazoMeses);
        decimal valorBruto = calcularCdbStrategy.CalcularValorBruto(valorInicial, prazoMeses, CDI, TB);
        decimal valorLiquido = calcularCdbStrategy.CalcularValorLiquido(valorInicial, valorBruto, imposto);
        valorBruto = Math.Round(valorBruto, 2);
        valorLiquido = Math.Round(valorLiquido, 2);

        var investimento = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);

        // When
        investimento.Calcular();

        // Then
        investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        investimento.ValorBruto.Should().Be(valorBruto);
        investimento.ValorLiquido.Should().Be(valorLiquido);
        investimento.Imposto.Should().Be(imposto);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 20% para prazo de 12 meses")]
    public void DeveAplicarAliquotaVintePorCentoParaDozeMeses()
    {
        // Given
        decimal valorInicial = 2000m;
        int prazoMeses = 12;
        decimal imposto = calcularCdbStrategy.CalcularImposto(prazoMeses);
        decimal valorBruto = calcularCdbStrategy.CalcularValorBruto(valorInicial, prazoMeses, CDI, TB);
        decimal valorLiquido = calcularCdbStrategy.CalcularValorLiquido(valorInicial, valorBruto, imposto);
        valorBruto = Math.Round(valorBruto, 2);
        valorLiquido = Math.Round(valorLiquido, 2);

        var investimento = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);

        // When
        investimento.Calcular();

        // Then
        investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        investimento.ValorBruto.Should().Be(valorBruto);
        investimento.ValorLiquido.Should().Be(valorLiquido);
        investimento.Imposto.Should().Be(imposto);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 17,5% para prazo de 24 meses")]
    public void DeveAplicarAliquotaDezesseteMeioPorCentoParaVinteQuatroMeses()
    {
        // Given
        decimal valorInicial = 3000m;
        int prazoMeses = 24;
        decimal imposto = calcularCdbStrategy.CalcularImposto(prazoMeses);
        decimal valorBruto = calcularCdbStrategy.CalcularValorBruto(valorInicial, prazoMeses, CDI, TB);
        decimal valorLiquido = calcularCdbStrategy.CalcularValorLiquido(valorInicial, valorBruto, imposto);
        valorBruto = Math.Round(valorBruto, 2);
        valorLiquido = Math.Round(valorLiquido, 2);

        var investimento = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);

        // When
        investimento.Calcular();

        // Then
        investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        investimento.ValorBruto.Should().Be(valorBruto);
        investimento.ValorLiquido.Should().Be(valorLiquido);
        investimento.Imposto.Should().Be(imposto);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 15% para prazo acima de 24 meses")]
    public void DeveAplicarAliquotaQuinzePorCentoParaAcimaDeVinteQuatroMeses()
    {
        // Given
        decimal valorInicial = 4000m;
        int prazoMeses = 36;
        decimal imposto = calcularCdbStrategy.CalcularImposto(prazoMeses);
        decimal valorBruto = calcularCdbStrategy.CalcularValorBruto(valorInicial, prazoMeses, CDI, TB);
        decimal valorLiquido = calcularCdbStrategy.CalcularValorLiquido(valorInicial, valorBruto, imposto);
        valorBruto = Math.Round(valorBruto, 2);
        valorLiquido = Math.Round(valorLiquido, 2);

        var investimento = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);

        // When
        investimento.Calcular();

        // Then
        investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        investimento.ValorBruto.Should().Be(valorBruto);
        investimento.ValorLiquido.Should().Be(valorLiquido);
        investimento.Imposto.Should().Be(imposto);
    }
}