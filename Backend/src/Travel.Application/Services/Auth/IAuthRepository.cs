using Travel.Model;

public interface IAuthRepository
{
    Task<Result<int>> SignUpAsync(SignUpDto signUp, CancellationToken token);
}