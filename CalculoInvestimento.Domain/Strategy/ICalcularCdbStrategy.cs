namespace CalculoInvestimento.Domain.Strategy;
public interface ICalcularCdbStrategy
{
    decimal CalcularValorBruto(decimal valor, int prazoMeses, decimal cdi, decimal tb);
}