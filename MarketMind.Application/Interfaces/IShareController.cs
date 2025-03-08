using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;

namespace MarketMind.Application.Interfaces;

/// <summary>
/// Интерфейс контроллра
/// </summary>
public interface IShareController
{
    /// <summary>
    /// Получить акцию
    /// </summary>
    /// <param name="id">Идентификатор акции</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GetShareResponse> GetShareAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить список акций
    /// </summary>
    /// <param name="request">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GetShareResponse[]> GetSharesAsync(GetSharesRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить кол-во акций с параметрами
    /// </summary>
    /// <param name="request">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<long> CountAsync(GetSharesCountRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Ресинхронизировать акции
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task ResyncAsync(CancellationToken cancellationToken);
}