using MarketMind.Application.Models.Responces;
using MarketMind.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace MarketMind.Application.Mappers.CandleMappers;

[Mapper]
public partial class CandleServiceMapper
{
    public partial GetCandleResponse Map(Candle entity);
    public partial GetCandleResponse[] Map(Candle[] entity);
}