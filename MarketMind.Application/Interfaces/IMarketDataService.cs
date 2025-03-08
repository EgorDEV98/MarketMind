using MarketMind.Application.Models.ExternalModels;
using Tinkoff.InvestApi.V1;

namespace MarketMind.Application.Interfaces;

public interface IMarketDataService
{
    public Task<HistoricCandle[]> GetHistoricCandleAsync(GetHistoricCandleModel model, CancellationToken cancellationToken);
}