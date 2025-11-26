using System.Security.Cryptography;
using EventPass.Domain.Interfaces.Security;

namespace EventPass.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        public (byte[] hash, byte[] salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                Algorithm,
                KeySize);

            return (hash, salt);
        }

        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                storedSalt,
                Iterations,
                Algorithm,
                KeySize);

            return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
        }
    }
}
