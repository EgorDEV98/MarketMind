using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers;
using MarketMind.Application.Services;
using MarketMind.Data.Settings;
using MarketMind.WebApi.Settings;

namespace MarketMind.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTinkoff(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var config = configuration.GetSection(nameof(TinkoffSettings))
            .Get<TinkoffSettings>();
        serviceCollection.AddInvestApiClient((_, builder) =>
        {
            builder.AccessToken = config.AccessToken;
            builder.Sandbox = config.Sandbox;
            builder.AppName = config.AppName;
        });
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddMappers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ShareMapper>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IShareService, SharesService>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddServiceOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<PostgresSettings>(configuration.GetSection(nameof(PostgresSettings)));
        
        return serviceCollection;
    }
}