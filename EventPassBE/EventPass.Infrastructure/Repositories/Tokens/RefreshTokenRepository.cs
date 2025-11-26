using EventPass.Domain.Entities.Token;
using EventPass.Domain.Interfaces.Tokens;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventPass.Infrastructure.Repositories.Tokens
{
    public class RefreshTokenRepository: IRefreshTokenRepository
    {
        private readonly EventPassDbContext _context;

        public RefreshTokenRepository(EventPassDbContext context)
        {
            _context = context;
        }

        public async Task AddRefreshTokenAsync(RefreshToken token, CancellationToken cancellationToken)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken)
        {
            var response = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);
            if (response == null) return null;
            return response;
        }

    }
}
