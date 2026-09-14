using Travel.Model;

namespace Travel.Application.Services.Auth;

public interface IAuthService
{
    Task<int> LoginAsync(
        LoginDto login,
        CancellationToken token);


    Task<Result<int>> SignUpAsync(
        SignUpDto register, 
        CancellationToken token);
}