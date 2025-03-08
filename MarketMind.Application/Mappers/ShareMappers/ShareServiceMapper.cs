using MarketMind.Application.Models.Responces;
using MarketMind.Data.Entities;
using Riok.Mapperly.Abstractions;

namespace MarketMind.Application.Mappers.ShareMappers;

[Mapper(AllowNullPropertyAssignment = false)]
public partial class ShareServiceMapper
{
    public partial GetShareResponse Map(Share share);
    public partial GetShareResponse[] Map(IEnumerable<Share> share);
    public partial Share Map(Tinkoff.InvestApi.V1.Share share);
}