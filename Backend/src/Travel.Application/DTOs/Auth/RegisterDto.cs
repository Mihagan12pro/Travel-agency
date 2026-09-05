using Travel.Model.Enums;

public record RegisterDto(
    string Login,
    string Password,
    EmployeeRoles Role);