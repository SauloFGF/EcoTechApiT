using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Infrastructure.Encrypt
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 10000;
        private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA512;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Iterations, HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(subkey, 0, hashBytes, SaltSize, HashSize);

            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] expectedSubkey = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, expectedSubkey, 0, HashSize);

            byte[] actualSubKey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Iterations, HashSize);

            for (int i = 0; i < HashSize; i++)
            {
                if (actualSubKey[i] != expectedSubkey[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
