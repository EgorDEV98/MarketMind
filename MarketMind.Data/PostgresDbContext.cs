using MarketMind.Data.Entities;
using MarketMind.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MarketMind.Data;

public class PostgresDbContext : DbContext
{
    /// <summary>
    /// Акции
    /// </summary>
    public DbSet<Share> Shares { get; set; }
    
    /// <summary>
    /// Бренды
    /// </summary>
    public DbSet<Brand> Brands { get; set; }
    
    /// <summary>
    /// Свечи
    /// </summary>
    public DbSet<Candle> Candles { get; set; }

    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new CandleConfiguration());
        builder.ApplyConfiguration(new BrandConfiguration());
        builder.ApplyConfiguration(new ShareConfiguration());
    }
}