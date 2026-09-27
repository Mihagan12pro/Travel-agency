using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Services.Users;
using Travel.Model.Staff;

namespace Travel.DataAccess.Repositories
{
    internal class UsersRepositoryV1 : IUsersRepository
    {
        private readonly AppDbContext _dbContext;

        public async Task<Employee> ExtractEmployeeAsync(int userId, CancellationToken token)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                return null;

            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == user.EmployeeId);

            return employee;
        }

        public UsersRepositoryV1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
