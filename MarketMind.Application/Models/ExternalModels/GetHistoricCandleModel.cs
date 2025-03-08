using Tinkoff.InvestApi.V1;

namespace MarketMind.Application.Models.ExternalModels;

public class GetHistoricCandleModel
{
    public required CandleInterval Interval { get; set; }
    public required string Figi { get; set; }
    public required DateTimeOffset From { get; set; }
    public required DateTimeOffset To { get; set; }
}