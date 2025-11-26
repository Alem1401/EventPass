using EventPass.Domain.Entities.Token;

namespace EventPass.Domain.Interfaces.Tokens
{
    public interface IRefreshTokenRepository
    {
        public Task AddRefreshTokenAsync(RefreshToken token, CancellationToken cancellationToken);
        public Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken);
    }
}
