using MarketMind.Application.Interfaces;
using MarketMind.Application.Mappers.CandleMappers;
using MarketMind.Application.Models.Params;
using MarketMind.Application.Models.Requests;
using MarketMind.Application.Models.Responces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMind.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CandlesController : ControllerBase, ICandlesController
{
    private readonly ICandlesService _candlesService;
    private readonly CandleRequestMapper _mapper;

    public CandlesController(ICandlesService candlesService, CandleRequestMapper mapper)
    {
        _candlesService = candlesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить свечу по Id
    /// </summary>
    /// <param name="id">Идентификатор свечи</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetCandleResponse> GetCandleAsync([FromRoute] Guid id, CancellationToken ct)
        => await _candlesService.GetCandleAsync(new GetCandleParams() { Id = id }, ct);

    /// <summary>
    /// Получить список свечей с параметрами
    /// </summary>
    /// <param name="candleParams">Параметра</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IReadOnlyCollection<GetCandleResponse>> GetCandlesAsync(GetCandlesRequest candleParams, CancellationToken ct)
        => await _candlesService.GetCandlesAsync(_mapper.Map(candleParams), ct);

    /// <summary>
    /// Поставить свечу на загрузку
    /// </summary>
    /// <param name="candleParams">Параметры</param>
    /// <param name="ct">Токен</param>
    /// <returns></returns>
    [HttpGet("load")]
    public async Task LoadCandlesAsync(LoadCandleRequest candleParams, CancellationToken ct)
        => await _candlesService.LoadCandlesAsync(new LoadCandleParams(){ Interval = candleParams.Interval, ShareId = candleParams.ShareId }, ct);
}