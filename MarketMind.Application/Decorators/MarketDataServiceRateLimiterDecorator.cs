using MarketMind.Application.Interfaces;
using MarketMind.Application.Models.ExternalModels;
using Polly;
using Polly.Registry;
using Tinkoff.InvestApi.V1;

namespace MarketMind.Application.Decorators;

public class MarketDataServiceRateLimiterDecorator : IMarketDataService
{
    private readonly IMarketDataService _marketDataService;
    private readonly ResiliencePipeline<HistoricCandle[]> _pipelineProvider;

    public MarketDataServiceRateLimiterDecorator(IMarketDataService marketDataService, ResiliencePipelineProvider<string> pipelineProvider)
    {
        _marketDataService = marketDataService;
        _pipelineProvider = pipelineProvider.GetPipeline<HistoricCandle[]>(key: nameof(MarketDataServiceRateLimiterDecorator));
    }
    
    public async Task<HistoricCandle[]> GetHistoricCandleAsync(GetHistoricCandleModel model, CancellationToken cancellationToken)
        => await _pipelineProvider.ExecuteAsync(async token => await _marketDataService.GetHistoricCandleAsync(model, token), cancellationToken);
}