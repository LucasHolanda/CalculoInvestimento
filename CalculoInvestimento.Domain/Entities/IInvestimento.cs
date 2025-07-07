namespace CalculoInvestimento.Domain.Entities;
public interface IInvestimento
{
    decimal ValorBruto { get; }
    decimal ValorLiquido { get; }
}