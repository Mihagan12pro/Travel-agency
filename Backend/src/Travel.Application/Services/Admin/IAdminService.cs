using Travel.Application.DTOs.Employee;

namespace Travel.Application.Services.Admin
{
    public interface IAdminService
    {
        Task AddEmployeeAsync(ICAOEmployeeDataDto employeeData, CancellationToken token);
    }
}
