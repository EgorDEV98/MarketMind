using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;
using MarketMind.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace MarketMind.Application.Mappers;

[Mapper(AllowNullPropertyAssignment = false)]
public partial class ShareMapper
{
    public partial GetSharesParams Map(GetSharesRequest request);
    public partial GetSharesCountParams Map(GetSharesCountRequest request);
    public partial GetShareResponse Map(Share share);
    public partial GetShareResponse[] Map(IEnumerable<Share> share);
    public partial Share Map(Tinkoff.InvestApi.V1.Share share);
}