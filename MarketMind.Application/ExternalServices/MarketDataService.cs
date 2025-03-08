using Google.Protobuf.WellKnownTypes;
using MarketMind.Application.Interfaces;
using MarketMind.Application.Models.ExternalModels;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;

namespace MarketMind.Application.ExternalServices;

public class MarketDataService(InvestApiClient apiClient) : IMarketDataService
{
    public async Task<HistoricCandle[]> GetHistoricCandleAsync(GetHistoricCandleModel model,  CancellationToken cancellationToken)
        => (await apiClient.MarketData.GetCandlesAsync(new GetCandlesRequest()
        {
            Interval = model.Interval,
            InstrumentId = model.Figi,
            CandleSourceType = GetCandlesRequest.Types.CandleSource.Exchange,
            From = Timestamp.FromDateTimeOffset(model.From),
            To = Timestamp.FromDateTimeOffset(model.To),
        }, cancellationToken: cancellationToken)).Candles.ToArray();
}