using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.WebApi.Options;
using Microsoft.Extensions.Options;

public class CdbTaxaConfigProvider : ICdbTaxaProvider
{
    private readonly BancoTaxaCdbOptions _bancoTaxaCdb;
    public CdbTaxaConfigProvider(IOptions<BancoTaxaCdbOptions> options) => _bancoTaxaCdb = options.Value;
    public Task<(decimal TB, decimal CDI)> ObterTaxasAsync() => Task.FromResult((_bancoTaxaCdb.TB, _bancoTaxaCdb.CDI));
}