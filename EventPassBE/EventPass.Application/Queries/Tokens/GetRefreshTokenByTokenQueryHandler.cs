using EventPass.Domain.Entities.Token;
using EventPass.Domain.Interfaces.Tokens;
using MediatR;

namespace EventPass.Application.Queries.Tokens
{
    public class GetRefreshTokenByTokenQueryHandler: IRequestHandler<GetRefreshTokenByTokenQuery, RefreshToken>
    {
        IRefreshTokenRepository _repository;

        public GetRefreshTokenByTokenQueryHandler(IRefreshTokenRepository repository)
        {
            _repository = repository;
        }

        public async Task<RefreshToken> Handle(GetRefreshTokenByTokenQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetByTokenAsync(query.token, cancellationToken);
        }
    }
}
