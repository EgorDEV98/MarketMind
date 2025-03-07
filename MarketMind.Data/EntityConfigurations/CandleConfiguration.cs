using MarketMind.Data.Convertors;
using MarketMind.Data.Entities;
using MarketMind.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarketMind.Data.EntityConfigurations;

public class CandleConfiguration : IEntityTypeConfiguration<Candle>
{
    public void Configure(EntityTypeBuilder<Candle> builder)
    {
        var candleIntervalConvertor = new ValueConverter<CandleInterval, string>(
            x => EnumConverters.ToEnumString(x),
            x => EnumConverters.ToEnum<CandleInterval>(x),
            new ConverterMappingHints(size: 20, unicode: false));
        
        var candleSourceTypeConvertor = new ValueConverter<CandleSource, string>(
            x => EnumConverters.ToEnumString(x),
            x => EnumConverters.ToEnum<CandleSource>(x),
            new ConverterMappingHints(size: 20, unicode: false));
        
        builder.HasKey(c => c.Id);
        builder.Property(x => x.Open).IsRequired();
        builder.Property(x => x.High).IsRequired();
        builder.Property(x => x.Low).IsRequired();
        builder.Property(x => x.Close).IsRequired();
        builder.Property(x => x.Interval).HasConversion(candleIntervalConvertor).IsRequired();
        builder.Property(x => x.Volume).IsRequired();
        builder.Property(x => x.Time).IsRequired();
        builder.Property(x => x.IsComplete).IsRequired();
        builder.Property(x => x.CandleSourceType).HasConversion(candleSourceTypeConvertor).IsRequired();
        builder.Property(x => x.IsComplete).IsRequired();
        
        builder.HasOne(x => x.Share)
            .WithMany(x => x.Candles)
            .HasForeignKey(x => x.ShareId);
    }
}