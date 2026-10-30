using System;
using System.Security.Cryptography;

namespace KooliProjekt.Application.Infrastructure.Security
{
    public static class PasswordHash
    {
        // Login is not implemented in the original project. This format must be
        // verified by the future login implementation; never compare it with plain text.
        public static string Create(string password)
        {
            const int iterations = 600000;
            var salt = RandomNumberGenerator.GetBytes(16);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, 32);

            return "pbkdf2-sha256$" + iterations + "$" +
                Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }
    }
}
