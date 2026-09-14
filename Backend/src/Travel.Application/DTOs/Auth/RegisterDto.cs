using Travel.Model.Enums;

public record SignUpDto(
    string Login,
    string Password,
    EmployeeRoles Role);