namespace MarketMind.WebApi.Settings;

/// <summary>
/// Настройки Тинькофф апи
/// </summary>
public class TinkoffSettings
{
    /// <summary>
    /// Токен доступа
    /// </summary>
    public string AccessToken { get; set; }
    
    /// <summary>
    /// Песочница
    /// </summary>
    public bool Sandbox { get; set; }
    
    /// <summary>
    /// Имя приложния
    /// </summary>
    public string AppName { get; set; }
}