using MarketMind.Data.Enums;

namespace MarketMind.Application.Models.Params;

/// <summary>
/// Параметры получения списка свечей
/// </summary>
public class GetCandlesParams
{
    /// <summary>
    /// Интервал
    /// </summary>
    public CandleInterval? Interval { get; set; }
    
    /// <summary>
    /// Признак завершённости свечи. false — свеча за текущие интервал ещё сформирована не полностью.
    /// </summary>
    public bool? IsComplete { get; set; }
    
    /// <summary>
    /// Внешний ключ
    /// </summary>
    public Guid? ShareId { get; set; }
    
    /// <summary>
    /// Отступ
    /// </summary>
    public int? Offset { get; set; }
    
    /// <summary>
    /// Лимит
    /// </summary>
    public int? Limit { get; set; }
}