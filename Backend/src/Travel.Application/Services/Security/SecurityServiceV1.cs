using System.Security.Cryptography;
using System.Text;

namespace Travel.Application.Services.Security
{
    public class SecurityServiceV1 : ISecurityService
    {
        public string HashSha256(string str)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(str));

            return Encoding.UTF8.GetString(hash);
        }
    }
}
