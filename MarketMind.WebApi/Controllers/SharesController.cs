using MarketMind.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMind.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SharesController : ControllerBase
{
    private readonly IShareService _sharesService;

    public SharesController(IShareService sharesService)
    {
        _sharesService = sharesService;
    }

    /// <summary>
    /// Ресинхронизация акций
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("resync")]
    public async Task ResyncAsync(CancellationToken cancellationToken)
        => await _sharesService.ResyncAsync(cancellationToken);
}