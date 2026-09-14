namespace Travel.Application.Services.Security
{
    public interface ISecurityService
    {
        string HashSha256(string str);
    }
}
