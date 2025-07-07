using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.Factory;
using FluentAssertions;
using NSubstitute;

namespace CalculoInvestimento.Tests.Unit.WebApi
{
    public class CalcularInvestimentoCdbTests
    {
        const decimal TB = 1.08m;
        const decimal CDI = 0.009m;
        [Fact(DisplayName = "Deve calcular investimento CDB com taxas corretas")]
        public async Task DeveCalcularInvestimentoCdbComTaxasCorretas()
        {
            // Given
            var valor = 1000m;
            var prazo = 12;
            var calcularCdbStrategy = new CalcularCdbStrategy();

            var investimentoEsperado = new InvestimentoCdb(valor, prazo, TB, CDI, calcularCdbStrategy);
            investimentoEsperado.Calcular();

            var cdbTaxaProvider = Substitute.For<ICdbTaxaProvider>();
            cdbTaxaProvider.ObterTaxasAsync().Returns(Task.FromResult<(decimal, decimal)>((TB, CDI)));

            var service = new CalcularInvestimentoCdb(calcularCdbStrategy, cdbTaxaProvider);

            // When
            InvestimentoCdb? resultado = await service.Calcular(valor, prazo) as InvestimentoCdb;
            resultado?.Calcular();

            // Then
            resultado.Should().NotBeNull();
            resultado.Should().BeOfType<InvestimentoCdb>();
            resultado.ValorBruto.Should().Be(investimentoEsperado.ValorBruto);
            resultado.ValorLiquido.Should().Be(investimentoEsperado.ValorLiquido);
            await cdbTaxaProvider.Received(1).ObterTaxasAsync();
        }
    }
}