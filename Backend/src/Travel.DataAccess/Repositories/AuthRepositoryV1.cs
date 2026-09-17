using Microsoft.EntityFrameworkCore;
using Npgsql;
using Travel.Application.DTOs.Auth;
using Travel.Model;
using Travel.Model.Staff;

namespace Travel.DataAccess.Repositories
{
    internal class AuthRepositoryV1 : IAuthRepository
    {
        private readonly AppDbContext _dbContext;

        public async Task<Result<int>> SignUpAsync(SignUpDto signUp, CancellationToken token)
        {
            Result<int> result = null;

            try
            {
                Employee employee = await _dbContext.Employees.FirstAsync(e => e.HashedPassport == signUp.Passport, token);

                StaffUser user = new StaffUser()
                {
                    EmployeeId = employee.Id,

                    HashedPassword = signUp.Password,

                    Login = signUp.Login,

                    Role = employee.Role
                };

                await _dbContext.Users.AddAsync(user, token);

                await _dbContext.SaveChangesAsync(token);

                result = new Result<int>(true, 200);
            }
            catch(InvalidOperationException)
            {
                result = new Result<int>(false, 404, "Такого сотрудника не существует!");
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                result = new Result<int>(false, 409, "Ошибка! Попробуйте снова");
            }
            catch
            {
                result = new Result<int>(false, 500);
            }


            return result;
        }

        public async Task<Result<GetUserDto>> LoginAsync(LoginDto login, CancellationToken token)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
                u.Login == login.Login && 
                u.HashedPassword == login.Password,
                token
            );

            if (user == null)
                return new Result<GetUserDto>(false, null);

            return new Result<GetUserDto>(true, new GetUserDto(user.Id, user.Login, user.Role));
        }

        public AuthRepositoryV1(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
