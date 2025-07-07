using CalculoInvestimento.WebApi.Options;
using FluentAssertions;
using Microsoft.Extensions.Options;

namespace CalculoInvestimento.Tests.Unit.WebApi
{
    public class CdbTaxaConfigProviderTests
    {
        [Fact(DisplayName = "Deve retornar taxas TB e CDI configuradas corretamente")]
        public async Task DeveRetornarTaxasConfiguradasCorretamente()
        {
            // Given
            var tbEsperado = 0.95m;
            var cdiEsperado = 0.13m;

            var options = Options.Create(new BancoTaxaCdbOptions
            {
                TB = tbEsperado,
                CDI = cdiEsperado
            });

            var provider = new CdbTaxaConfigProvider(options);

            // When
            var (tb, cdi) = await provider.ObterTaxasAsync();

            // Then
            tb.Should().Be(tbEsperado);
            cdi.Should().Be(cdiEsperado);
        }
    }
}
