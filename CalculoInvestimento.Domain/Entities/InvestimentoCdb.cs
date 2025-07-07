using CalculoInvestimento.Domain.Strategy;

namespace CalculoInvestimento.Domain.Entities
{
    public class InvestimentoCdb: IInvestimento
    {
        private readonly IImpostoStrategy _impostoStrategy;
        private readonly ICalcularCdbStrategy _calcularCdbStrategy;

        public decimal ValorInicial { get; private set; }
        public int PrazoMeses { get; private set; }
        public decimal Imposto { get; private set; }
        public decimal ValorImposto { get; private set; }
        public decimal ValorBruto { get; private set; }
        public decimal ValorLiquido { get; private set; }
        public DateTime DataCalculo { get; private set; } = DateTime.UtcNow;
        public decimal Tb { get; private set; }
        public decimal Cdi { get; private set; }

        public InvestimentoCdb(decimal valorInicial
                             , int prazoMeses
                             , decimal tb
                             , decimal cdi
                             , IImpostoStrategy impostoStrategy
                             , ICalcularCdbStrategy calcularCdbStrategy)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
            Tb = tb;
            Cdi = cdi;
            _impostoStrategy = impostoStrategy;
            _calcularCdbStrategy = calcularCdbStrategy;
        }

        public async Task CalcularCDBAsync()
        {
            var taskCalcularValorBruto = Task.Run(() => _calcularCdbStrategy.CalcularValorBruto(ValorInicial, PrazoMeses, Cdi, Tb));
            var taskImposto = Task.Run(() => _impostoStrategy.CalcularAliquota(PrazoMeses));

            Imposto = await taskImposto;
            ValorBruto = await taskCalcularValorBruto;

            ValorImposto = ((ValorBruto - ValorInicial) * Imposto);
            ValorLiquido = ValorBruto - ValorImposto;

            ValorBruto = Math.Round(ValorBruto, 2);
            ValorLiquido = Math.Round(ValorLiquido, 2);
        }
    }
}
