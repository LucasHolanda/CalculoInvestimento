using CalculoInvestimento.Domain.Entities;
using CalculoInvestimento.Domain.Service;
using Microsoft.Extensions.Caching.Memory;

public class CalcularCdbCacheDecorator : ICalcularCdbService
{
    private readonly ICalcularCdbService _inner;
    private readonly IMemoryCache _cache;

    public CalcularCdbCacheDecorator(ICalcularCdbService inner, IMemoryCache cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public async Task<InvestimentoCdb?> CalcularAsync(decimal valor, int prazoMeses)
    {
        var cacheKey = $"cdb_{valor}_{prazoMeses}";
        if (_cache.TryGetValue(cacheKey, out InvestimentoCdb? cached))
            return cached;

        var result = await _inner.CalcularAsync(valor, prazoMeses);
        _cache.Set(cacheKey, result, TimeSpan.FromHours(1));
        return result;
    }
}