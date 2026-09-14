using Travel.Application.Services.Auth;
using Travel.Application.Services.Security;
using Travel.Model;

internal class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    private readonly ISecurityService _securityService;

    public async Task<int> LoginAsync(LoginDto login, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<int>> SignUpAsync(SignUpDto signUp, CancellationToken token)
    {
        signUp = signUp with
        {
            Passport = _securityService.HashSha256(signUp.Passport),

            Password = _securityService.HashSha256(signUp.Password)
        };


        return await _authRepository.SignUpAsync(signUp, token);
    }

    public AuthService(IAuthRepository authRepository, ISecurityService securityService)
    {
        _authRepository = authRepository;
        _securityService = securityService;
    }
}