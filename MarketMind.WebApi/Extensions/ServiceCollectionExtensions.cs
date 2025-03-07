using MarketMind.Data.Settings;

namespace MarketMind.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<PostgresSettings>(configuration.GetSection(nameof(PostgresSettings)));
        
        return serviceCollection;
    }
}