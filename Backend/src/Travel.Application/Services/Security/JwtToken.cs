using System.Text;

namespace Travel.Application.Services.Security
{
    public class JwtToken
    {
        public string ExpiredMinutes { get; set; }

        public string Issuer { get; set; }

        public byte[] IssuerSigningKey { get; set; }

        public string SecretKey
        {
            get => Encoding.UTF8.GetString(IssuerSigningKey);

            set => IssuerSigningKey = Encoding.UTF8.GetBytes(value);
        }

        public string[] Audiences { get; set; }
    }
}
