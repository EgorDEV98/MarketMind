using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;

namespace MarketMind.Application.Interfaces;


/// <summary>
/// Интерфейс контроллра свечей
/// </summary>
public interface ICandlesController
{
    /// <summary>
    /// Получить свечу по Id
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public Task<GetCandleResponse> GetCandleAsync(Guid id, CancellationToken ct);
    
    /// <summary>
    /// Получить список свечей
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    public Task<IReadOnlyCollection<GetCandleResponse>> GetCandlesAsync(GetCandlesRequest candleParams, CancellationToken ct);
    
    /// <summary>
    /// Запустить загрузку акции
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns></returns>
    public Task LoadCandlesAsync(LoadCandleRequest candleParams, CancellationToken ct);
}