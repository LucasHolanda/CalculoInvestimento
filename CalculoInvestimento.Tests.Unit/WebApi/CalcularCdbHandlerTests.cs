using AutoMapper;
using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.Domain.Strategy;
using CalculoInvestimento.WebApi.CalcularCdb;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

public class CalcularCdbHandlerTests
{
    private readonly ICalcularCdbService _service;
    private readonly ICalcularCdbStrategy calcularCdbStrategy;
    private readonly IMapper _mapper;
    const decimal TB = 1.08m;
    const decimal CDI = 0.009m;

    public CalcularCdbHandlerTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(InvestimentoCdbProfile).Assembly));
        _mapper = config.CreateMapper();
        calcularCdbStrategy = new CalcularCdbStrategy();
        _service = Substitute.For<ICalcularCdbService>();
    }

    [Fact(DisplayName = "Handler deve retornar DTO calculado quando serviço retorna resultado")]
    public async Task Handler_DeveRetornarDtoCalculado_QuandoServicoRetornaResultado()
    {
        // Given
        decimal valorInicial = 1000m;
        int prazoMeses = 12;
        var command = new CalcularCdbCommand { Valor = 1000, PrazoMeses = 12 };
        var investimentoResult = new InvestimentoCdb(valorInicial, prazoMeses, TB, CDI, calcularCdbStrategy);
        investimentoResult.Calcular();
        var expectedDto = _mapper.Map<InvestimentoCdbDto>(investimentoResult);

        _service.CalcularAsync(command.Valor, command.PrazoMeses).Returns(investimentoResult);
        var handler = new CalcularCdbHandler(_service, _mapper);

        // When
        var result = await handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().BeEquivalentTo(expectedDto);
    }

    [Fact(DisplayName = "Handler deve lançar exceção quando serviço retorna nulo")]
    public async Task Handler_DeveLancarExcecao_QuandoServicoRetornaNulo()
    {
        // Given
        var command = new CalcularCdbCommand { Valor = 0, PrazoMeses = 0 };
        _service.CalcularAsync(command.Valor, command.PrazoMeses).ReturnsNull();
        var handler = new CalcularCdbHandler(_service, _mapper);

        // When
        var act = async () => await handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Nao foi possivel calcular o CDB!");
    }
}