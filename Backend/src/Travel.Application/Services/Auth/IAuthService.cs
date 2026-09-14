namespace Travel.Application.Services.Auth;

public interface IAuthService
{
    Task<int> LoginAsync(
        LoginDto login,
        CancellationToken token);


    Task<int> SignUpAsync(
        SignUpDto register, 
        CancellationToken token);
}