using MarketMind.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketMind.Data.EntityConfigurations;

public class ShareConfiguration : IEntityTypeConfiguration<Share>
{
    public void Configure(EntityTypeBuilder<Share> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Figi).IsRequired();
        builder.Property(x => x.Ticker).IsRequired();
        builder.Property(x => x.Lot).IsRequired();
        builder.Property(x => x.ShortEnabledFlag).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.CountryOfRisk).IsRequired();
        builder.Property(x => x.CountryOfRiskName).IsRequired();
        builder.Property(x => x.MinPriceIncrement).IsRequired();
        builder.Property(x => x.ForQualInvestorFlag).IsRequired();
        builder.Property(x => x.WeekendFlag).IsRequired();
        builder.Property(x => x.First1MinCandleDate).IsRequired();
        builder.Property(x => x.First1DayCandleDate).IsRequired();

        builder.HasIndex(x => new { x.Figi, x.Ticker}).IsUnique();
    }
}