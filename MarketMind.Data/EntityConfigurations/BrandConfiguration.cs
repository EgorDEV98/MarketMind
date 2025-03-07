using MarketMind.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketMind.Data.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.LogoName).IsRequired();
        builder.Property(x => x.LogoBaseColor).IsRequired();
        builder.Property(x => x.TextColor).IsRequired();
        
        builder.HasOne(x => x.Share)
            .WithOne(x => x.Brand)
            .HasForeignKey<Brand>(x => x.ShareId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}