using System.ComponentModel.DataAnnotations;
using Travel.Model.Enums;

namespace Travel.Application.DTOs.Employee
{
    public record ICAOEmployeeDataDto(
        [Required, MinLength(3)] string Name, 
        [Required, MinLength(3)] string Surname, 
        [MinLength(5)] string? Patronymic,
        [Required, Length(10, 10), RegularExpression("^\\d{4}[\\s-]?\\d{6}$")] string Passport,
        EmployeeRoles Role);
}
