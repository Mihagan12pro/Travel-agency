using Travel.Model.Enums;

namespace Travel.Application.DTOs.Employee
{
    public record GetEmployeeDto(
        string Name, 
        string Surname, 
        string? Patronymic,
        EmployeeRoles Role
    );
}
