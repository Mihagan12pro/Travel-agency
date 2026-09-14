using Travel.Application.Services.Auth;

internal class AuthService : IAuthService
{
    public async Task<int> LoginAsync(LoginDto login, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SignUpAsync(SignUpDto register, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}