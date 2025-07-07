using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.WebApi.Service;
using FluentAssertions;

public class CalcularCdbServiceTests
{
    [Fact(DisplayName = "Service deve calcular corretamente o valor bruto e líquido do CDB")]
    public async Task Service_DeveCalcularCorretamenteValoresBrutoELiquido()
    {
        // Given
        //var service = new CalcularCdbService();
        //decimal valorInicial = 1000m;
        //int prazoMeses = 12;
        //const decimal TB = 1.08m;
        //const decimal CDI = 0.009m;
        //var investimentoResult = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI);
        //await investimentoResult.CalcularCDBAsync();

        //// When
        //var investimento = await service.CalcularAsync(valorInicial, prazoMeses);

        //// Then
        //investimento.Should().NotBeNull();

        //investimento.ValorInicial.Should().Be(investimentoResult.ValorInicial);
        //investimento.PrazoMeses.Should().Be(investimentoResult.PrazoMeses);


        //investimento.ValorBruto.Should().Be(investimentoResult.ValorBruto);
        //investimento.ValorLiquido.Should().Be(investimentoResult.ValorLiquido);
    }
}