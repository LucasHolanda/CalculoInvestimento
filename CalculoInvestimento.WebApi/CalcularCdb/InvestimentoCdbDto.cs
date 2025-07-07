namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class InvestimentoCdbDto
    {
        public decimal ValorInicial { get; set; }
        public int PrazoMeses { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
    }
}