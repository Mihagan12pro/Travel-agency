using Travel.Model.Enums;

namespace Travel.Application.DTOs.Security
{
    public record CreateTokenDto(
        string Login, 
        int UserId,
        EmployeeRoles Role);
}
