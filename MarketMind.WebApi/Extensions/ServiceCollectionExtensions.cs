using System.Threading.RateLimiting;
using MarketMind.Application.Decorators;
using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers.CandleMappers;
using MarketMind.Application.Mappers.ShareMappers;
using MarketMind.Application.Services;
using MarketMind.Data.Settings;
using MarketMind.WebApi.Settings;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using Polly.Retry;
using Tinkoff.InvestApi.V1;
using MarketDataService = MarketMind.Application.ExternalServices.MarketDataService;

namespace MarketMind.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommon(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<MarketDataServiceRateLimiterDecorator>();
        
        return serviceCollection;
    }
    public static IServiceCollection AddRateLimiters(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<MarketDataServiceRateLimiterDecorator>();
        serviceCollection.AddResiliencePipeline<string, HistoricCandle[]>(
            nameof(MarketDataServiceRateLimiterDecorator),
            (builder, _) =>
            {
                builder.ConfigureTelemetry(NullLoggerFactory.Instance)
                    .AddRetry(
                        new RetryStrategyOptions<HistoricCandle[]>()
                        {
                            Delay = TimeSpan.FromMilliseconds(500),
                            MaxRetryAttempts = 5,
                            BackoffType = DelayBackoffType.Exponential
                        })
                    .AddRateLimiter(
                        new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions()
                        {
                            Window = TimeSpan.FromMinutes(1),
                            QueueLimit = 600,
                            PermitLimit = 550
                        }));
            });
        
        return serviceCollection;
    }
    public static IServiceCollection AddTinkoff(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var config = configuration.GetSection(nameof(TinkoffSettings))
            .Get<TinkoffSettings>();
        serviceCollection.AddInvestApiClient((_, builder) =>
        {
            builder.AccessToken = config!.AccessToken;
            builder.Sandbox = config.Sandbox;
            builder.AppName = config.AppName;
        });
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ShareServiceMapper>();
        serviceCollection.AddSingleton<ShareRequestMapper>();
        serviceCollection.AddSingleton<CandleServiceMapper>();
        serviceCollection.AddSingleton<CandleRequestMapper>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IShareService, SharesService>();
        serviceCollection.AddScoped<ICandlesService, CandlesService>();
        serviceCollection.AddScoped<IMarketDataService, MarketDataService>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddServiceOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<PostgresSettings>(configuration.GetSection(nameof(PostgresSettings)));
        
        return serviceCollection;
    }
}