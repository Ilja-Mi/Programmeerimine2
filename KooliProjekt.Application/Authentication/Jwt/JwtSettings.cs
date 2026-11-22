using System;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace KooliProjekt.Application.Authentication.Jwt
{
    public class JwtSettings
    {
        public string Key { get; }
        public string Issuer { get; }
        public string Audience { get; }
        public int ExpireMinutes { get; }
        public JwtSettings(IConfiguration config)
        {
            var section = config.GetSection("Jwt");
            Key = section["Key"];
            Issuer = section["Issuer"];
            Audience = section["Audience"];
            if (string.IsNullOrWhiteSpace(Key) || Encoding.UTF8.GetByteCount(Key) < 32)
                throw new InvalidOperationException("Set Jwt:Key to a secret of at least 32 UTF-8 bytes.");
            if (string.IsNullOrWhiteSpace(Issuer) || string.IsNullOrWhiteSpace(Audience))
                throw new InvalidOperationException("Jwt:Issuer and Jwt:Audience are required.");
            if (!int.TryParse(section["ExpireMinutes"] ?? "60", out var minutes) || minutes < 1 || minutes > 1440)
                throw new InvalidOperationException("Jwt:ExpireMinutes must be between 1 and 1440.");
            ExpireMinutes = minutes;
        }
    }
}
