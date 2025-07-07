namespace CalculoInvestimento.Domain.Strategy;
public interface IImpostoStrategy
{
    decimal CalcularAliquota(int prazoMeses);
}