using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;

namespace MarketMind.Application.Interfaces;

/// <summary>
/// Интерфейс контроллера
/// </summary>
public interface IShareService
{
    /// <summary>
    /// Получить акцию
    /// </summary>
    /// <param name="parameters">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GetShareResponse> GetShareAsync(GetShareParams parameters, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить список акций
    /// </summary>
    /// <param name="parameters">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<GetShareResponse[]> GetSharesAsync(GetSharesParams parameters, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить кол-во акций с параметрами
    /// </summary>
    /// <param name="parameters">Параметры</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<long> CountAsync(GetSharesCountParams parameters, CancellationToken cancellationToken);
    
    /// <summary>
    /// Ресинхронизировать акции
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<bool> ResyncAsync(CancellationToken cancellationToken);
}