namespace EventPass.Domain.Interfaces.Security
{
    public interface IPasswordHasher
    {
        (byte[] hash, byte[] salt) HashPassword(string password);
        bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}
