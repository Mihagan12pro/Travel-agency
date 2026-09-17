using Travel.Model.Staff;

namespace Travel.Application.Services.Admin
{
    public interface IEmployeesRepository
    {
        Task<int> AddAsync(Employee employee, CancellationToken cancellationToken);
    }
}
