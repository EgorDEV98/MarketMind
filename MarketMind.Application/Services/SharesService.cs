using AppResponseExtension.Exceptions;
using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers;
using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Responces;
using MarketMind.Data;
using MarketMind.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Tinkoff.InvestApi;
using NotImplementedException = System.NotImplementedException;

namespace MarketMind.Application.Services;

public class SharesService : IShareService
{
    private readonly PostgresDbContext _context;
    private readonly ShareMapper _mapper;
    private readonly InvestApiClient _apiClient;

    public SharesService(PostgresDbContext context, ShareMapper mapper, InvestApiClient apiClient)
    {
        _context = context;
        _mapper = mapper;
        _apiClient = apiClient;
    }
    
    /// <summary>
    /// Получить акцию по Id
    /// </summary>
    /// <param name="parameters">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetShareResponse> GetShareAsync(GetShareParams parameters, CancellationToken cancellationToken)
    {
        var share = await _context.Shares
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == parameters.Id, cancellationToken);
        if (share is null)
        {
            NotFoundException.Throw($"Share with id: {parameters.Id} not found");
        }
        
        return _mapper.Map(share!);
    }

    /// <summary>
    /// Получить список акций с параметрами
    /// </summary>
    /// <param name="parameters">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetShareResponse[]> GetSharesAsync(GetSharesParams parameters, CancellationToken cancellationToken)
    {
        var entities = await _context.Shares
            .AsNoTracking()
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Figi), x => x.Figi.ToLower().Contains(parameters.Figi!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Ticker), x => x.Ticker.ToLower().Contains(parameters.Ticker!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.CountryOfRisk), x => x.CountryOfRisk.ToLower().Contains(parameters.CountryOfRisk!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.CountryOfRiskName), x => x.CountryOfRiskName.ToLower().Contains(parameters.CountryOfRiskName!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Name), x => x.Name.ToLower().Contains(parameters.Name!.ToLower()))
            .WhereIf(parameters.WeekendFlag.HasValue, x => x.WeekendFlag == parameters.WeekendFlag)
            .WhereIf(parameters.ShortEnabledFlag.HasValue, x => x.ShortEnabledFlag == parameters.ShortEnabledFlag)
            .WhereIf(parameters.ForQualInvestorFlag.HasValue, x => x.ForQualInvestorFlag == parameters.ForQualInvestorFlag)
            .Skip(parameters.Offset ?? 0)
            .Take(parameters.Limit ?? 100)
            .ToArrayAsync(cancellationToken);
        
        return _mapper.Map(entities);
    }

    /// <summary>
    /// Количество акций
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<long> CountAsync(GetSharesCountParams parameters, CancellationToken cancellationToken)
        => await _context.Shares
            .AsNoTracking()
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Figi), x => x.Figi.ToLower().Contains(parameters.Figi!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Ticker), x => x.Ticker.ToLower().Contains(parameters.Ticker!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.CountryOfRisk), x => x.CountryOfRisk.ToLower().Contains(parameters.CountryOfRisk!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.CountryOfRiskName), x => x.CountryOfRiskName.ToLower().Contains(parameters.CountryOfRiskName!.ToLower()))
            .WhereIf(!string.IsNullOrWhiteSpace(parameters.Name), x => x.Name.ToLower().Contains(parameters.Name!.ToLower()))
            .WhereIf(parameters.WeekendFlag.HasValue, x => x.WeekendFlag == parameters.WeekendFlag)
            .WhereIf(parameters.ShortEnabledFlag.HasValue, x => x.ShortEnabledFlag == parameters.ShortEnabledFlag)
            .WhereIf(parameters.ForQualInvestorFlag.HasValue, x => x.ForQualInvestorFlag == parameters.ForQualInvestorFlag)
            .LongCountAsync(cancellationToken);

    /// <summary>
    /// Ресинхронизация акций(загрузка и добавление/обновление)
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> ResyncAsync(CancellationToken cancellationToken)
    {
        var shares = await _context.Shares
            .Include(x => x.Brand)
            .ToArrayAsync(cancellationToken);
        
        var tinkoffShares = (await _apiClient.Instruments.SharesAsync()).Instruments
            .Where(x => x.MinPriceIncrement != null)
            .Where(x => x.First1MinCandleDate != null)
            .Where(x => x.First1DayCandleDate != null)
            .ToArray();

        foreach (var tfShare in tinkoffShares)
        {
            // Если тикер уж был то обновляем, если нет, то добавлям
            var currentShare = shares.FirstOrDefault(x => x.Ticker == tfShare.Ticker);
            if (currentShare is not null)
            {
                currentShare.WeekendFlag = tfShare.WeekendFlag;
                currentShare.CountryOfRisk = tfShare.CountryOfRisk;
                currentShare.CountryOfRiskName = tfShare.CountryOfRiskName;
                currentShare.Name = tfShare.Name;
                currentShare.ShortEnabledFlag = tfShare.ShortEnabledFlag;
                currentShare.Figi = tfShare.Figi;
                currentShare.Ticker = tfShare.Ticker;
                currentShare.MinPriceIncrement = tfShare.MinPriceIncrement;
                currentShare.First1DayCandleDate = tfShare.First1DayCandleDate.ToDateTimeOffset();
                currentShare.ForQualInvestorFlag = tfShare.ForQualInvestorFlag;
                currentShare.Lot = tfShare.Lot;
                currentShare.First1MinCandleDate = tfShare.First1MinCandleDate.ToDateTimeOffset();
                currentShare.Brand.LogoName = tfShare.Brand.LogoName;
                currentShare.Brand.LogoBaseColor = tfShare.Brand.LogoBaseColor;
                currentShare.Brand.TextColor = tfShare.Brand.TextColor;
                continue;
            }
            await _context.Shares.AddAsync(_mapper.Map(tfShare), cancellationToken);

        }
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}