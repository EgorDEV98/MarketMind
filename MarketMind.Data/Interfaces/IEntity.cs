namespace MarketMind.Data.Interfaces;

/// <summary>
/// Базовый интерфейс сущностей
/// </summary>
public interface IEntity
{
    ///Идентификатор <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }
}