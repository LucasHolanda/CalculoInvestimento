using CalculoInvestimento.Domain.Strategy;

namespace CalculoInvestimento.Domain.Entities
{
    public class InvestimentoCdb : IInvestimento
    {
        private readonly ICalcularCdbStrategy _calcularCdbStrategy;

        public decimal ValorInicial { get; private set; }
        public int PrazoMeses { get; private set; }
        public decimal Imposto { get; private set; }
        public decimal ValorImposto { get; private set; }
        public decimal ValorBruto { get; private set; }
        public decimal ValorLiquido { get; private set; }
        public decimal ValorRendimentoBruto { get; private set; }
        public decimal ValorRendimentoLiquido { get; private set; }
        public DateTime DataCalculo { get; private set; } = DateTime.UtcNow;
        public decimal Tb { get; private set; }
        public decimal Cdi { get; private set; }

        public InvestimentoCdb(decimal valorInicial
                             , int prazoMeses
                             , decimal tb
                             , decimal cdi
                             , ICalcularCdbStrategy calcularCdbStrategy)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
            Tb = tb;
            Cdi = cdi;
            _calcularCdbStrategy = calcularCdbStrategy;
        }

        public void Calcular()
        {
            Imposto = _calcularCdbStrategy.CalcularImposto(PrazoMeses);
            ValorBruto = _calcularCdbStrategy.CalcularValorBruto(ValorInicial, PrazoMeses, Cdi, Tb);

            ValorLiquido = _calcularCdbStrategy.CalcularValorLiquido(ValorInicial, ValorBruto, Imposto);

            ValorBruto = Math.Round(ValorBruto, 2);
            ValorLiquido = Math.Round(ValorLiquido, 2);
            ValorImposto = ValorBruto - ValorLiquido;
            ValorRendimentoBruto = ValorBruto - ValorInicial;
            ValorRendimentoLiquido = ValorLiquido - ValorInicial;
        }
    }
}
