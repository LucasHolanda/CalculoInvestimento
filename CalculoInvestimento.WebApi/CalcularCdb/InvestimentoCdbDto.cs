namespace CalculoInvestimento.WebApi.CalcularCdb
{
    public class InvestimentoCdbDto
    {
        public int PrazoMeses { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal Imposto { get; set; }
        public decimal ValorImposto { get; set; }
        public decimal ValorRendimentoLiquido { get; set; }
        public decimal ValorRendimentoBruto { get; set; }
        public DateTime DataCalculo { get; private set; }
    }
}