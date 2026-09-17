using System;
using System.Collections.Generic;
using System.Text;
using Travel.Model.Staff;

namespace Travel.Application.Services.Users
{
    public interface IUsersRepository
    {
        Task<Employee> ExtractEmployeeAsync(
            int userId,
            CancellationToken token);
    }
}
