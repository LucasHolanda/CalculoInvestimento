namespace CalculoInvestimento.Domain.Strategy;
public class CalcularCdbStrategy : ICalcularCdbStrategy
{
    public decimal CalcularImposto(int prazoMeses)
    {
        if (prazoMeses <= 6) return 0.225m;
        if (prazoMeses <= 12) return 0.20m;
        if (prazoMeses <= 24) return 0.175m;
        return 0.15m;
    }

    public decimal CalcularValorBruto(decimal valor, int prazoMeses, decimal cdi, decimal tb)
    {
        decimal valorBruto = valor;
        for (int i = 0; i < prazoMeses; i++)
        {
            valorBruto *= (1 + (cdi * tb));
        }

        return valorBruto;
    }

    public decimal CalcularValorLiquido(decimal valor, decimal valorBruto, decimal imposto)
    {
        var valorImposto = ((valorBruto - valor) * imposto);
        return valorBruto - valorImposto;
    }
}