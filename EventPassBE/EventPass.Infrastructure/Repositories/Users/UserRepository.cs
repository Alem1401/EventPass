using EventPass.Domain.Entities.Users;
using EventPass.Domain.Interfaces.Users;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly EventPassDbContext _context;

        public UserRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken ct)
        {
            return await _context.Users.ToListAsync(ct);
        }
        public async Task<User> GetUserByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
        }
        public async Task<User> GetUserByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(), ct);
        }
        public async Task<User> AddUserAsync(User user, CancellationToken ct)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(ct);
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id, ct);
        }
        public async Task<bool> DeleteUserAsync(int id, CancellationToken ct)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            return false;
        }
        public async Task<User> UpdateUserAsync(User user, CancellationToken ct)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(ct);
            return user;
        }
    }
}
