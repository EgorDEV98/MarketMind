using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using Riok.Mapperly.Abstractions;

namespace MarketMind.Application.Mappers.CandleMappers;

[Mapper]
public partial class CandleRequestMapper
{
    public partial GetCandlesParams Map(GetCandlesRequest request);
}