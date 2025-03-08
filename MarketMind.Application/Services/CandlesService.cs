using AppResponseExtension.Exceptions;
using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers.CandleMappers;
using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Responces;
using MarketMind.Data;
using MarketMind.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using NotImplementedException = System.NotImplementedException;

namespace MarketMind.Application.Services;

public class CandlesService : ICandlesService
{
    private readonly PostgresDbContext _context;
    private readonly CandleServiceMapper _mapper;

    public CandlesService(PostgresDbContext context, CandleServiceMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Получить свечу по Id
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public async Task<GetCandleResponse> GetCandleAsync(GetCandleParams candleParams, CancellationToken ct)
    {
        var entity = await _context.Candles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == candleParams.Id, ct);
        if (entity == null)
        {
            NotFoundException.Throw($"Candle Id ({candleParams.Id}) not found");
        }
        return _mapper.Map(entity!);
    }

    /// <summary>
    /// Получить список свечей
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public async Task<IReadOnlyCollection<GetCandleResponse>> GetCandlesAsync(GetCandlesParams candleParams, CancellationToken ct)
    {
        var entities = await _context.Candles
            .AsNoTracking()
            .WhereIf(candleParams.Interval.HasValue, x => x.Interval >= candleParams.Interval)
            .WhereIf(candleParams.IsComplete.HasValue, x => x.IsComplete == candleParams.IsComplete)
            .WhereIf(candleParams.ShareId.HasValue, x => x.ShareId == candleParams.ShareId)
            .Skip(candleParams.Offset ?? 0)
            .Take(candleParams.Limit ?? 100)
            .ToArrayAsync(ct);
        return _mapper.Map(entities);
    }

    /// <summary>
    /// Поставить свечи на загрузку
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public async Task<bool> LoadCandlesAsync(LoadCandleParams candleParams, CancellationToken ct)
    {
        return true;
    }
}