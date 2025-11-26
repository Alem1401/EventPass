using EventPass.Domain.Entities.Token;
using MediatR;

namespace EventPass.Application.Queries.Tokens
{
    public class GetRefreshTokenByTokenQuery: IRequest<RefreshToken>
    {
        public string token {  get; set; }
    }
}
