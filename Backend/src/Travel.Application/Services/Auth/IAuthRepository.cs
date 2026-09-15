using Travel.Application.DTOs.Auth;
using Travel.Model;

public interface IAuthRepository
{
    Task<Result<int>> SignUpAsync(SignUpDto signUp, CancellationToken token);

    Task<Result<GetUserDto>> GetUserAsync(LoginDto login, CancellationToken token);
}