using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.DTOs.Employee;
using Travel.Application.Services.Security;

namespace Travel.Application.Services.Admin
{
    internal class AdminService : IAdminService
    {
        private readonly ISecurityService _security; 

        public async Task AddEmployeeAsync(ICAOEmployeeDataDto employeeData, CancellationToken token)
        {
            string hashedPassport = _security.HashSha256(employeeData.Passport);
        }

        public AdminService(ISecurityService security)
        {
            _security = security;
        }
    }
}
