namespace CalculoInvestimento.Domain.Strategy;
public interface ICalcularCdbStrategy
{
    decimal CalcularImposto(int prazoMeses);
    decimal CalcularValorBruto(decimal valor, int prazoMeses, decimal cdi, decimal tb);
    decimal CalcularValorLiquido(decimal valor, decimal valorBruto, decimal imposto);
}