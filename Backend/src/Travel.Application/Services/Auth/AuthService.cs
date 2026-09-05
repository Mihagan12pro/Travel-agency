using Travel.Application.Services.Auth;

internal class AuthService : IAuthService
{
    public async Task<int> GetRegisterResultAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PendingRegister>> GetRegisters(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<int> LoginAsync(LoginDto login, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task ProcessRegisterAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<int> TryRigisterAsync(RegisterDto register, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}