using MarketMind.Data.Interfaces;

namespace MarketMind.Data.Entities;

/// <summary>
/// Акция
/// </summary>
public class Share : IEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Фиги
    /// </summary>
    public string Figi { get; set; }
    
    /// <summary>
    /// Тикер
    /// </summary>
    public string Ticker { get; set; }
    
    /// <summary>
    /// Лотность
    /// </summary>
    public int Lot { get; set; }
    
    /// <summary>
    /// Признак доступности для операций в шорт
    /// </summary>
    public bool ShortEnabledFlag { get; set; }
    
    /// <summary>
    /// Название инструмента
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Код страны риска — то есть страны, в которой компания ведёт основной бизнес
    /// </summary>
    public string CountryOfRisk { get; set; }
    
    /// <summary>
    /// Наименование страны риска — то есть страны, в которой компания ведёт основной бизнес
    /// </summary>
    public string CountryOfRiskName { get; set; }
    
    /// <summary>
    /// Шаг цены
    /// </summary>
    public decimal MinPriceIncrement { get; set; }
    
    /// <summary>
    /// Флаг, отображающий доступность торговли инструментом только для квалифицированных инвесторов
    /// </summary>
    public bool ForQualInvestorFlag { get; set; }
    
    /// <summary>
    /// Флаг, отображающий доступность торговли инструментом по выходным
    /// </summary>
    public bool WeekendFlag { get; set; }
    
    /// <summary>
    /// Дата первой минутной свечи
    /// </summary>
    public DateTimeOffset First1MinCandleDate { get; set; }
    
    /// <summary>
    /// Дата первой дневной свечи
    /// </summary>
    public DateTimeOffset First1DayCandleDate { get; set; }
    
    /// <summary>
    /// Бренд
    /// </summary>
    public Brand Brand { get; set; }
    
    /// <summary>
    /// Свечи
    /// </summary>
    public ICollection<Candle> Candles { get; set; }
}