using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Enum;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.Factory;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace CalculoInvestimento.Tests.Unit.WebApi
{
    public class InvestimentoFactoryTests
    {
        private readonly ICalcularCdbStrategy calcularCdbStrategy;
        const decimal TB = 1.08m;
        const decimal CDI = 0.009m;
        public InvestimentoFactoryTests()
        {
            calcularCdbStrategy = new CalcularCdbStrategy();
        }

        [Fact(DisplayName = "Deve criar investimento CDB corretamente")]
        public async Task DeveCriarInvestimentoCdbCorretamente()
        {
            // Given
            var valor = 1000m;
            var prazo = 12;
            var tipo = TipoInvestimento.Cdb;
            var investimentoEsperado = new InvestimentoCdb(valor, prazo, TB, CDI, calcularCdbStrategy);
            investimentoEsperado.Calcular();

            var calcularCdb = Substitute.For<ICalcularInvestimentoCdb>();
            calcularCdb.Calcular(valor, prazo).Returns(investimentoEsperado);

            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(ICalcularInvestimentoCdb)).Returns(calcularCdb);
            serviceProvider.GetRequiredService(typeof(ICalcularInvestimentoCdb)).Returns(calcularCdb);

            var scope = Substitute.For<IServiceScope>();
            scope.ServiceProvider.Returns(serviceProvider);

            var scopeFactory = Substitute.For<IServiceScopeFactory>();
            scopeFactory.CreateScope().Returns(scope);

            var factory = new InvestimentoFactory(scopeFactory);

            // When
            var resultado = await factory.Criar(tipo, valor, prazo);

            // Then
            resultado.Should().Be(investimentoEsperado);
            await calcularCdb.Received(1).Calcular(valor, prazo);
        }

        [Fact(DisplayName = "Deve lançar exceção quando tipo de investimento não implementado")]
        public async Task DeveLancarExcecaoQuandoTipoNaoImplementado()
        {
            // Given
            var tipoInvalido = (TipoInvestimento)999;
            var scopeFactory = Substitute.For<IServiceScopeFactory>();
            var scope = Substitute.For<IServiceScope>();
            var serviceProvider = Substitute.For<IServiceProvider>();

            scope.ServiceProvider.Returns(serviceProvider);
            scopeFactory.CreateScope().Returns(scope);

            var factory = new InvestimentoFactory(scopeFactory);

            // When
            Func<Task> acao = async () => await factory.Criar(tipoInvalido, 1000m, 12);

            // Then
            await acao.Should().ThrowAsync<NotImplementedException>();
        }
    }
}
