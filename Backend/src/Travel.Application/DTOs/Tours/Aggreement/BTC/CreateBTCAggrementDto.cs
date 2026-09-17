using System.ComponentModel.DataAnnotations;

namespace Travel.Application.DTOs.Tours.Aggreement.BTC
{
    public record CreateBTCAggrementDto(
        [MinLength(6)] string FullName,
        [Required, Length(10, 10), RegularExpression("^\\d{4}[\\s-]?\\d{6}$")] string ClientPassport,
        [Required] string Description);
}
