using AutoMapper;
using CalculoInvestimento.Domain.Service;
using CalculoInvestimento.WebApi.CalcularCdb;
using Microsoft.Extensions.Caching.Memory;

namespace CalculoInvestimento.WebApi.Service
{
    // TODO: remove
    //public class CalcularCdbCacheService : ICalcularCdbService
    //{
    //    private readonly IMemoryCache _cache;
    //    private readonly ICalcularCdbService _service;
    //    private readonly IMapper _mapper;

    //    public CalcularCdbCacheService(IMemoryCache cache, ICalcularCdbService service, IMapper mapper)
    //    {
    //        _cache = cache;
    //        _service = service;
    //        _mapper = mapper;
    //    }

    //    public async Task<InvestimentoCdbDto?> CalcularAsync(CalcularCdbCommand command)
    //    {
    //        var cacheKey = $"cdb_{command.Valor}_{command.PrazoMeses}";
    //        return await _cache.GetOrCreateAsync(cacheKey, async entry =>
    //        {
    //            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
    //            var investimento = await _service.CalcularAsync(command.Valor, command.PrazoMeses);
    //            var result = _mapper.Map<InvestimentoCdbDto>(investimento);
    //            return result ?? throw new InvalidOperationException("Nao foi possivel calcular o CDB!");
    //        });
    //    }
    //}
}
