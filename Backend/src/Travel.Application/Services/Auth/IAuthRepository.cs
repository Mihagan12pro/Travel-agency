using Travel.Application.DTOs.Auth;
using Travel.Model;

public interface IAuthRepository
{
    Task<Result<int>> SignUpAsync(SignUpDto signUp, CancellationToken token);

    Task<Result<GetUserDto>> LoginAsync(LoginDto login, CancellationToken token);
}