using Travel.Application.Services.Admin;
using Travel.Model;

namespace Travel.DataAccess.Repositories
{
    internal class EmployeesRepositoryV1 : IEmployeesRepository
    {
        private readonly AppDbContext _dbContext;

        public async Task<int> AddAsync(Employee employee, CancellationToken token)
        {
            await _dbContext.Employees.AddAsync(employee, token);
            await _dbContext.SaveChangesAsync(token);

            return employee.Id;
        }

        public EmployeesRepositoryV1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
