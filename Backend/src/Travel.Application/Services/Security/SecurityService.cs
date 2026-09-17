using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Travel.Application.DTOs.Security;

namespace Travel.Application.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly IHttpContextAccessor _httpContext;

        public string CreateJwt(CreateTokenDto createTokenDto)
        {
            var jwtVariable = Environment.GetEnvironmentVariable("TravelJwt");
            JwtToken jwt = JsonSerializer.Deserialize<JwtToken>(jwtVariable);

            var claims = new Dictionary<string, object>
            {
                [JwtRegisteredClaimNames.Jti] = Guid.NewGuid().ToString(),

                [JwtRegisteredClaimNames.Iss] = jwt.Issuer
            };

            var key = new SymmetricSecurityKey(jwt.IssuerSigningKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            int minutes = int.Parse(jwt.ExpiredMinutes);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, createTokenDto.UserId.ToString()),

                    new Claim("role", createTokenDto.Role.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(minutes),
                
                Claims = claims,

                SigningCredentials = creds,
            };

            foreach (var aud in jwt.Audiences)
                descriptor.Audiences.Add(aud);

            var tokenString = new JsonWebTokenHandler().CreateToken(descriptor);

            return tokenString;
        }

        public string HashSha256(string str)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(str));

            return Convert.ToHexString(hash);
        }

        public string JwtClaimExtractor(string claimName)
            => _httpContext.HttpContext.User.FindFirst(claimName).Value;

        public SecurityService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
    }
}
