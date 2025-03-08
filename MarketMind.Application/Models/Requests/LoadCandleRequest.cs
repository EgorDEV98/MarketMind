using System.ComponentModel.DataAnnotations;
using MarketMind.Data.Enums;

namespace MarketMind.Application.Models.Requests;

public class LoadCandleRequest
{
    /// <summary>
    /// Интервал
    /// </summary>
    [Required]
    public required CandleInterval[] Interval { get; set; }
    
    /// <summary>
    /// Id акции
    /// </summary>
    [Required]
    public required Guid ShareId { get; set; }
}