using MarketMind.Data.Interfaces;

namespace MarketMind.Data.Entities;

/// <summary>
/// Бренд
/// </summary>
public class Brand : IEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Логотип инструмента. Имя файла для получения логотипа
    /// </summary>
    public string LogoName { get; set; }
    
    /// <summary>
    /// Цвет бренда
    /// </summary>
    public string LogoBaseColor { get; set; }
    
    /// <summary>
    /// Цвет текста для цвета логотипа бренда
    /// </summary>
    public string TextColor { get; set; }
    
    /// <summary>
    /// Навигационное поле
    /// </summary>
    public Share Share { get; set; }
    
    /// <summary>
    /// Внешний ключ
    /// </summary>
    public Guid ShareId { get; set; }
}