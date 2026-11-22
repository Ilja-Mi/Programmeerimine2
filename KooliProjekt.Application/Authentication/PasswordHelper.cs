using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KooliProjekt.Application.Authentication
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;

        public static string Hash(string password)
        {
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                HashSize);

            var combined = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, combined, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, combined, SaltSize, HashSize);

            return Convert.ToBase64String(combined);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword)) return false;
            try
            {
                byte[] salt;
                byte[] storedHash;
                int iterations = Iterations;
                if (hashedPassword.StartsWith("pbkdf2-sha256$", StringComparison.Ordinal))
                {
                    var parts = hashedPassword.Split('$');
                    if (parts.Length != 4 || !int.TryParse(parts[1], out iterations)
                        || iterations < 100_000 || iterations > 1_000_000) return false;
                    salt = Convert.FromBase64String(parts[2]);
                    storedHash = Convert.FromBase64String(parts[3]);
                }
                else
                {
                    var combined = Convert.FromBase64String(hashedPassword);
                    if (combined.Length != SaltSize + HashSize) return false;
                    salt = combined[..SaltSize];
                    storedHash = combined[SaltSize..];
                }
                if (salt.Length != SaltSize || storedHash.Length != HashSize) return false;
                var computedHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, HashSize);
                return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
            }
            catch (FormatException) { return false; }
        }
    }
}
