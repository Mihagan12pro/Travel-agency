namespace Travel.Application.Services.Auth;

public interface IAuthService
{
    Task<int> LoginAsync(
        LoginDto login,
        CancellationToken token);

    Task<int> TryRigisterAsync(
        RegisterDto register,
        CancellationToken token);

    Task ProcessRegisterAsync(
        int id, 
        CancellationToken token);
    
    Task<int> GetRegisterResultAsync(
        int id, 
        CancellationToken token); 

    Task<IEnumerable<PendingRegister>> GetRegisters(CancellationToken token);
}