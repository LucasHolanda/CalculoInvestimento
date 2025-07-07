using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using NSubstitute;

public class CalcularCdbCacheDecoratorTests
{
    private readonly ICalcularCdbService _service;
    private readonly ICalcularCdbStrategy calcularCdbStrategy;    
    const decimal TB = 1.08m;
    const decimal CDI = 0.009m;

    public CalcularCdbCacheDecoratorTests()
    {
        calcularCdbStrategy = new CalcularCdbStrategy();
        _service = Substitute.For<ICalcularCdbService>();
    }

    [Fact(DisplayName = "CalcularAsync deve retornar do cache quando existir")]
    public async Task CalcularAsync_DeveRetornarDoCache_QuandoExistir()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 12;
        var investimentoResult = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);

        var cache = Substitute.For<IMemoryCache>();

        cache.TryGetValue(Arg.Any<object>(), out Arg.Any<object?>())
            .Returns(x =>
            {
                x[1] = investimentoResult; // out parameter
                return true;
            });

        var decorator = new CalcularCdbCacheDecorator(_service, cache);

        // When
        var result = await decorator.CalcularAsync(valorInicial, prazoMeses);

        // Then
        result.Should().BeEquivalentTo(investimentoResult);
        await _service.DidNotReceive().CalcularAsync(Arg.Any<decimal>(), Arg.Any<int>());
    }

    [Fact(DisplayName = "CalcularAsync deve calcular quando nao existir no cache")]
    public async Task CalcularAsync_DeveCalcular_QuandoNaoExistirNoCache()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 12;
        var investimentoResult = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);
        investimentoResult.Calcular();

        var inner = Substitute.For<ICalcularCdbService>();
        inner.CalcularAsync(valorInicial, prazoMeses).Returns(Task.FromResult<InvestimentoCdb?>(investimentoResult));

        var cache = Substitute.For<IMemoryCache>();

        cache.TryGetValue(Arg.Any<InvestimentoCdb>(), out Arg.Any<InvestimentoCdb?>())
            .Returns(x =>
            {
                x[1] = null;
                return false;
            });

        var decorator = new CalcularCdbCacheDecorator(inner, cache);

        // When
        var result = await decorator.CalcularAsync(valorInicial, prazoMeses);

        // Then
        result.Should().BeEquivalentTo(investimentoResult);
        await inner.Received(1).CalcularAsync(valorInicial, prazoMeses);
    }
}