using System.Runtime.Serialization;

namespace MarketMind.Data.Enums;

/// <summary>
/// Интервал
/// </summary>
public enum CandleInterval
{
    /// <summary>
    /// Интервал не определён
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_UNSPECIFIED")]
    Unspecified = 0,
    
    /// <summary>
    /// От 1 минуты до 1 дня (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_1_MIN")]
    _1Min = 1,
    
    /// <summary>
    /// От 5 минут до недели (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_5_MIN")]
    _5Min = 2,
    
    /// <summary>
    /// От 15 минут до 3 недель (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_15_MIN")]
    _15Min = 3,
    
    /// <summary>
    /// От 1 часа до 3 месяцев (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_HOUR")]
    Hour = 4,
    
    /// <summary>
    /// От 1 дня до 6 лет (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_DAY")]
    Day = 5,
    
    /// <summary>
    /// От 2 минут до 1 дня (лимит 1200)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_2_MIN")]
    _2Min = 6,
    
    /// <summary>
    /// От 3 минут до 1 дня (лимит 750)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_3_MIN")]
    _3Min = 7,
    
    /// <summary>
    /// От 10 минут до недели (лимит 1200)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_10_MIN")]
    _10Min = 8,
    
    /// <summary>
    /// От 30 минут до 3 недель (лимит 1200)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_30_MIN")]
    _30Min = 9,
    
    /// <summary>
    /// От 2 часов до 3 месяцев (лимит 2400)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_2_HOUR")]
    _2Hour = 10,
    
    /// <summary>
    /// От 4 часов до 3 месяцев (лимит 700)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_4_HOUR")]
    _4Hour = 11,
    
    /// <summary>
    /// От 1 недели до 5 лет (лимит 300)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_WEEK")]
    Week = 12,
    
    /// <summary>
    /// От 1 месяца до 10 лет (лимит 120)
    /// </summary>
    [EnumMember(Value = "CANDLE_INTERVAL_MONTH")]
    Month = 13,
}