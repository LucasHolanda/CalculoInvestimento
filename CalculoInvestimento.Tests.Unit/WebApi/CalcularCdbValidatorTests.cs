using CalculoInvestimento.WebApi.CalcularCdb;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace CalculoInvestimento.Tests.Unit.WebApi
{
    public class CalcularCdbValidatorTests
    {
        [Fact(DisplayName = "Deve validar corretamente quando dados são válidos")]
        public void DeveValidarCorretamenteQuandoDadosValidos()
        {
            // Given
            var validator = new CalcularCdbValidator();
            var command = new CalcularCdbCommand
            {
                Valor = 1000m,
                PrazoMeses = 12
            };

            // When
            var resultado = validator.TestValidate(command);

            // Then
            resultado.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve falhar quando valor é menor ou igual a zero")]
        public void DeveFalharQuandoValorMenorOuIgualZero()
        {
            // Given
            var validator = new CalcularCdbValidator();
            var command = new CalcularCdbCommand
            {
                Valor = 0,
                PrazoMeses = 12
            };

            // When
            var resultado = validator.TestValidate(command);

            // Then
            resultado.ShouldHaveValidationErrorFor(x => x.Valor)
                     .WithErrorMessage("Valor deve ser positivo");
        }

        [Fact(DisplayName = "Deve falhar quando prazo é menor ou igual a 1")]
        public void DeveFalharQuandoPrazoMenorOuIgualAUm()
        {
            // Given
            var validator = new CalcularCdbValidator();
            var command = new CalcularCdbCommand
            {
                Valor = 1000m,
                PrazoMeses = 1
            };

            // When
            var resultado = validator.TestValidate(command);

            // Then
            resultado.ShouldHaveValidationErrorFor(x => x.PrazoMeses)
                     .WithErrorMessage("Período deve ser maior que 1 mês");
        }
    }
}
