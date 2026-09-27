using Travel.Model.Enums;

namespace Travel.Application.DTOs.Auth
{
    public record GetUserDto(
        int Id, 
        string Login,
        EmployeeRoles Role);
}
