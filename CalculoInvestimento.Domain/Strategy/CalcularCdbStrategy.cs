namespace CalculoInvestimento.Domain.Strategy;
public class CalcularCdbStrategy : ICalcularCdbStrategy
{
    public decimal CalcularValorBruto(decimal valor, int prazoMeses, decimal cdi, decimal tb)
    {
        decimal valorBruto = valor;
        for (int i = 0; i < prazoMeses; i++)
        {
            valorBruto *= (1 + (cdi * tb));
        }

        return valorBruto;
    }
}