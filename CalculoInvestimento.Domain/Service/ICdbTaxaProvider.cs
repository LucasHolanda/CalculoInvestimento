namespace CalculoInvestimento.Domain.Service;
public interface ICdbTaxaProvider
{
    Task<(decimal TB, decimal CDI)> ObterTaxasAsync();
}