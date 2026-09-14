using Travel.Application.DTOs.Employee;
using Travel.Application.Extensions;
using Travel.Application.Services.Security;
using Travel.Model;

namespace Travel.Application.Services.Admin
{
    internal class AdminService : IAdminService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly ISecurityService _security; 

        public async Task AddEmployeeAsync(ICAOEmployeeDataDto employeeData, CancellationToken token)
        {
            string hashedPassport = _security.HashSha256(employeeData.Passport);

            Employee employee = new Employee()
            {
                HashedPassport = hashedPassport,

                Name = employeeData.Name,

                SurName = employeeData.Surname,

                Patronymic = employeeData.Patronymic,

                Role = employeeData.Role
            };

            if (employeeData.Patronymic != null)
                employee.Patronymic = employeeData.Patronymic.Capitalize();

            employee.Name = employee.Name.Capitalize();
            employee.SurName = employee.SurName.Capitalize();

            await _employeesRepository.AddAsync(employee, token);
        }

        public AdminService(IEmployeesRepository employeesRepository, ISecurityService security)
        {
            _employeesRepository = employeesRepository;
            _security = security;
        }
    }
}
