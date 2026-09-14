using System.ComponentModel.DataAnnotations;
using Travel.Model.Enums;

namespace Travel.Model;

public class User
{
    [Key]
    public int Id { get; set; }

    public required int EmployeeId { get; set; }

    public required string HashedPassword { get; set; }

    public required string Login { get; set; }

    public required EmployeeRoles Role { get; set; }
}
