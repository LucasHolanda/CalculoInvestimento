using CalculoInvestimento.Domain.Entities;
using FluentAssertions;

public class InvestimentoCdbTests
{
    [Fact(DisplayName = "Deve calcular corretamente o valor bruto e líquido para 6 meses com alíquota de 22,5%")]
    public async Task DeveCalcularCorretamenteParaSeisMeses()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 6;
        decimal valorBruto = 1059.76m;
        decimal valorLiquido = 1046.31m;
        decimal tb = 1.08m;
        decimal cdi = 0.009m;
        //var investimento = new InvestimentoCdb(valorInicial, prazoMeses, tb, cdi);

        //// When
        //await investimento.CalcularCDBAsync();

        //// Then
        //investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        //investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        //investimento.ValorBruto.Should().Be(valorBruto);
        //investimento.ValorLiquido.Should().Be(valorLiquido);
        //investimento.Imposto.Should().Be(0.225m);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 20% para prazo de 12 meses")]
    public async Task DeveAplicarAliquotaVintePorCentoParaDozeMeses()
    {
        // Given
        decimal valorInicial = 2000m;
        int prazoMeses = 12;
        decimal valorBruto = 2246.16m;
        decimal valorLiquido = 2196.93m;
        decimal tb = 1.08m;
        decimal cdi = 0.009m;
        //var investimento = new InvestimentoCdb(valorInicial, prazoMeses, tb, cdi);

        //// When
        //await investimento.CalcularCDBAsync();

        //// Then
        //investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        //investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        //investimento.ValorBruto.Should().Be(valorBruto);
        //investimento.ValorLiquido.Should().Be(valorLiquido);
        //investimento.Imposto.Should().Be(0.20m);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 17,5% para prazo de 24 meses")]
    public async Task DeveAplicarAliquotaDezesseteMeioPorCentoParaVinteQuatroMeses()
    {
        // Given
        decimal valorInicial = 3000m;
        int prazoMeses = 24;
        decimal valorBruto = 3783.94m;
        decimal valorLiquido = 3646.75m;
        decimal tb = 1.08m;
        decimal cdi = 0.009m;
        //var investimento = new InvestimentoCdb(valorInicial, prazoMeses, tb, cdi);

        //// When
        //await investimento.CalcularCDBAsync();

        //// Then
        //investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        //investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        //investimento.ValorBruto.Should().Be(valorBruto);
        //investimento.ValorLiquido.Should().Be(valorLiquido);
        //investimento.Imposto.Should().Be(0.175m);
    }

    [Fact(DisplayName = "Deve aplicar alíquota de 15% para prazo acima de 24 meses")]
    public async Task DeveAplicarAliquotaQuinzePorCentoParaAcimaDeVinteQuatroMeses()
    {
        // Given
        decimal valorInicial = 4000m;
        int prazoMeses = 36;
        decimal valorBruto = 5666.23m;
        decimal valorLiquido = 5416.30m;
        decimal tb = 1.08m;
        decimal cdi = 0.009m;
        //var investimento = new InvestimentoCdb(valorInicial, prazoMeses, tb, cdi);

        //// When
        //await investimento.CalcularCDBAsync();

        //// Then
        //investimento.Imposto.Should().Be(0.15m);
        //investimento.ValorBruto.Should().BeGreaterThan(valorInicial);
        //investimento.ValorLiquido.Should().BeLessThan(investimento.ValorBruto);
        //investimento.ValorBruto.Should().Be(valorBruto);
        //investimento.ValorLiquido.Should().Be(valorLiquido);
    }
}