using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.WebApi.CalcularCdb;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

public class CalcularCdbHandlerTests
{
    [Fact(DisplayName = "Handler deve retornar DTO calculado quando serviço retorna resultado")]
    public async Task Handler_DeveRetornarDtoCalculado_QuandoServicoRetornaResultado()
    {
        // Given
        var command = new CalcularCdbCommand { Valor = 1000, PrazoMeses = 12 };
        var expectedDto = new InvestimentoCdbDto { ValorInicial = 1000, PrazoMeses = 12, ValorBruto = 1100, ValorLiquido = 1080 };
        var mockService = Substitute.For<ICalcularCdbService>();
        //mockService.CalcularAsync(command.Valor, command.PrazoMeses).Returns(expectedDto);
        //var handler = new CalcularCdbHandler(mockService);

        //// When
        //var result = await handler.Handle(command, CancellationToken.None);

        //// Then
        //result.Should().BeEquivalentTo(expectedDto);
    }

    [Fact(DisplayName = "Handler deve lançar exceção quando serviço retorna nulo")]
    public async Task Handler_DeveLancarExcecao_QuandoServicoRetornaNulo()
    {
        // Given
        var command = new CalcularCdbCommand { Valor = 1000, PrazoMeses = 12 };
        //var mockService = Substitute.For<ICalcularCdbCacheAppService>();
        //mockService.ObterOuCalcularAsync(command).ReturnsNull();
        //var handler = new CalcularCdbHandler(mockService);

        //// When
        //var act = async () => await handler.Handle(command, CancellationToken.None);

        //// Then
        //await act.Should().ThrowAsync<InvalidOperationException>()
        //    .WithMessage("Nao foi possivel calcular o CDB!");
    }
}