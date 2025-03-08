using MarketMind.Data.Enums;

namespace MarketMind.Application.Models.Params;

public class LoadCandleParams
{
    /// <summary>
    /// Интервал
    /// </summary>
    public required CandleInterval[] Interval { get; set; }
    
    /// <summary>
    /// Id акции
    /// </summary>
    public required Guid ShareId { get; set; }
}