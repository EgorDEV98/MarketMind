namespace MarketMind.Application.Models.Params;

public class GetSharesCountParams
{
    /// <summary>
    /// Фиги
    /// </summary>
    public string? Figi { get; set; }
    
    /// <summary>
    /// Тикер
    /// </summary>
    public string? Ticker { get; set; }
    
    /// <summary>
    /// Признак доступности для операций в шорт
    /// </summary>
    public bool? ShortEnabledFlag { get; set; }
    
    /// <summary>
    /// Название инструмента
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Код страны риска — то есть страны, в которой компания ведёт основной бизнес
    /// </summary>
    public string? CountryOfRisk { get; set; }
    
    /// <summary>
    /// Наименование страны риска — то есть страны, в которой компания ведёт основной бизнес
    /// </summary>
    public string? CountryOfRiskName { get; set; }
    
    /// <summary>
    /// Флаг, отображающий доступность торговли инструментом только для квалифицированных инвесторов
    /// </summary>
    public bool? ForQualInvestorFlag { get; set; }
    
    /// <summary>
    /// Флаг, отображающий доступность торговли инструментом по выходным
    /// </summary>
    public bool? WeekendFlag { get; set; }
}