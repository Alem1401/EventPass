using EventPass.Domain.Entities.Users;

namespace EventPass.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user, CancellationToken ct);
        Task<User> GetUserByIdAsync(int id, CancellationToken ct);  
        Task<User> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken ct);
        Task<bool> DeleteUserAsync(int id, CancellationToken ct);
        Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken);
    }
}
