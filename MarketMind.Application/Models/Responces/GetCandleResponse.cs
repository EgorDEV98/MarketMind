using MarketMind.Data.Enums;

namespace MarketMind.Application.Models.Responces;

public class GetCandleResponse
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Цена открытия за 1 инструмент. Чтобы получить стоимость лота, нужно умножить на лотность инструмента
    /// </summary>
    public decimal Open { get; set; }
    
    /// <summary>
    /// Максимальная цена за 1 инструмент. Чтобы получить стоимость лота, нужно умножить на лотность инструмента
    /// </summary>
    public decimal High { get; set; }
    
    /// <summary>
    /// Минимальная цена за 1 инструмент. Чтобы получить стоимость лота, нужно умножить на лотность инструмента
    /// </summary>
    public decimal Low { get; set; }
    
    /// <summary>
    /// Цена закрытия за 1 инструмент. Чтобы получить стоимость лота, нужно умножить на лотность инструмента
    /// </summary>
    public decimal Close { get; set; }
    
    /// <summary>
    /// Объём торгов в лотах
    /// </summary>
    public long Volume { get; set; }
    
    /// <summary>
    /// Интервал
    /// </summary>
    public CandleInterval Interval { get; set; }
    
    /// <summary>
    /// Время свечи в часовом поясе UTC
    /// </summary>
    public DateTimeOffset Time { get; set; }
    
    /// <summary>
    /// Признак завершённости свечи. false — свеча за текущие интервал ещё сформирована не полностью.
    /// </summary>
    public bool IsComplete { get; set; }
    
    /// <summary>
    /// Тип источника свечи
    /// </summary>
    public CandleSource CandleSourceType { get; set; }
}