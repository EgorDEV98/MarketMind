using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers.ShareMappers;
using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMind.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SharesController : ControllerBase, IShareController
{
    private readonly IShareService _sharesService;
    private readonly ShareRequestMapper _mapper;

    public SharesController(IShareService sharesService, ShareRequestMapper mapper)
    {
        _sharesService = sharesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить акцию
    /// </summary>
    /// <param name="id">Идентификатор акции</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetShareResponse> GetShareAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        => await _sharesService.GetShareAsync(new GetShareParams() { Id = id }, cancellationToken);
    
    /// <summary>
    /// Получить список акций с параметрами
    /// </summary>
    /// <param name="request">Параметры</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<GetShareResponse[]> GetSharesAsync([FromQuery] GetSharesRequest request, CancellationToken cancellationToken)
        => await _sharesService.GetSharesAsync(_mapper.Map(request), cancellationToken);

    /// <summary>
    /// Получить количество акций
    /// </summary>
    /// <param name="request">Параметры</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns></returns>
    [HttpGet("count")]
    public async Task<long> CountAsync([FromQuery] GetSharesCountRequest request, CancellationToken cancellationToken)
        => await _sharesService.CountAsync(_mapper.Map(request), cancellationToken);
    
    /// <summary>
    /// Ресинхронизация акций
    /// </summary>
    /// <param name="cancellationToken">Токен</param>
    [HttpGet("resync")]
    public async Task ResyncAsync(CancellationToken cancellationToken)
        => await _sharesService.ResyncAsync(cancellationToken);
}