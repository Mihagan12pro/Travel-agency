using Travel.Application.DTOs.Clients.BTC;
using Travel.Application.DTOs.Employee;

namespace Travel.Application.DTOs.Tours.Aggreement.BTC
{
    public record GetBTCAggreementDto(
        long Id,
        string Description,
        GetClientBTCDto Client,
        GetEmployeeDto Employee);
}
