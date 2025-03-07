using System.Runtime.Serialization;

namespace MarketMind.Data.Enums;

/// <summary>
/// Источник свечи
/// </summary>
public enum CandleSource
{
    /// <summary>
    /// Источник свечей не определён
    /// </summary>
    [EnumMember(Value = "CANDLE_SOURCE_UNSPECIFIED")]
    Unspecified = 0,
    
    /// <summary>
    /// Биржевые свечи
    /// </summary>
    [EnumMember(Value = "CANDLE_SOURCE_EXCHANGE")]
    Exchange = 1,
    
    /// <summary>
    /// Свечи дилера в результате торговли по выходным
    /// </summary>
    [EnumMember(Value = "CANDLE_SOURCE_DEALER_WEEKEND")]
    DealerWeekend = 2,
}