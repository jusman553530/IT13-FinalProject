using System;
using System.Security.Cryptography;

namespace CRM.infrastructure
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public static (string hash, string salt) Hash(string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(SaltSize);

            byte[] keyBytes = Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: saltBytes,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: KeySize);

            return (
                Convert.ToBase64String(keyBytes),
                Convert.ToBase64String(saltBytes));
        }

        public static bool Verify(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(storedSalt))
                return false;

            byte[] saltBytes;
            byte[] expectedHash;

            try
            {
                saltBytes = Convert.FromBase64String(storedSalt);
                expectedHash = Convert.FromBase64String(storedHash);
            }
            catch
            {
                return false;
            }

            byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: saltBytes,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}