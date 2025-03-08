using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Responces;

namespace MarketMind.Application.Interfaces;

/// <summary>
/// Интерфейс сервиса свечей
/// </summary>
public interface ICandlesService
{
    /// <summary>
    /// Получить свечу по Id
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public Task<GetCandleResponse> GetCandleAsync(GetCandleParams candleParams, CancellationToken ct);
    
    /// <summary>
    /// Получить список свечей
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public Task<IReadOnlyCollection<GetCandleResponse>> GetCandlesAsync(GetCandlesParams candleParams, CancellationToken ct);
    
    /// <summary>
    /// Запустить загрузку акции
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns></returns>
    public Task<bool> LoadCandlesAsync(LoadCandleParams candleParams, CancellationToken ct);
}