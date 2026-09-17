using Travel.Application.DTOs.Security;
using Travel.Application.Services.Auth;
using Travel.Application.Services.Security;
using Travel.Model;

internal class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    private readonly ISecurityService _securityService;

    public async Task<Result<string>> LoginAsync(LoginDto login, CancellationToken token)
    {
        login = login with
        {
            Password = _securityService.HashSha256(login.Password)
        };

        var result = await _authRepository.LoginAsync(login, token);

        if (!result.IsSuccess)
            return new Result<string>(false, null);

        var jwt = _securityService.CreateJwt(new CreateTokenDto(login.Login, result.Value.Id, result.Value.Role));

        return new Result<string>(true, jwt);
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