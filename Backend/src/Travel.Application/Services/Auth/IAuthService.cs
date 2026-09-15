using Travel.Model;

namespace Travel.Application.Services.Auth;

public interface IAuthService
{
    Task<Result<string>> LoginAsync(
        LoginDto login,
        CancellationToken token);


    Task<Result<int>> SignUpAsync(
        SignUpDto register, 
        CancellationToken token);
}