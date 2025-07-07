namespace CalculoInvestimento.Domain.Strategy;
public class ImpostoCdbStrategy : IImpostoStrategy
{
    public decimal CalcularAliquota(int prazoMeses)
    {
        if (prazoMeses <= 6) return 0.225m;
        if (prazoMeses <= 12) return 0.20m;
        if (prazoMeses <= 24) return 0.175m;
        return 0.15m;
    }
}