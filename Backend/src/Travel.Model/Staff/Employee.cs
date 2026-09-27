using System.ComponentModel.DataAnnotations;
using Travel.Model.Enums;

namespace Travel.Model.Staff
{
    public class Employee
    {
        public int Id { get; set; }

        public required string HashedPassport { get; set; }


        [MinLength(3)]
        public required string Name { get; set; }


        [MinLength(3)]
        public required string SurName { get; set; }

        [MinLength(3)]
        public string? Patronymic { get; set; }

        public required EmployeeRoles Role { get; set; }
    }
}
