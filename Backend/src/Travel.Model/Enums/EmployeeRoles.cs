using System.Text.Json.Serialization;

namespace Travel.Model.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EmployeeRoles
{
    Admin,

    Manager,

    Agent,

    Accountant
}