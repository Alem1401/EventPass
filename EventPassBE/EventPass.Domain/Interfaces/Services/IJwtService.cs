using EventPass.Domain.Entities.Users;

namespace EventPass.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
