using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using Riok.Mapperly.Abstractions;

namespace MarketMind.Application.Mappers.ShareMappers;

[Mapper]
public partial class ShareRequestMapper
{
    public partial GetSharesParams Map(GetSharesRequest request);
    public partial GetSharesCountParams Map(GetSharesCountRequest request);
}