using EventPass.Domain.Entities.Token;
using EventPass.Domain.Interfaces.Tokens;
using MediatR;

namespace EventPass.Application.Commands.Tokens.Create
{
    public class CreateRefreshTokenCommandHandler: IRequestHandler<CreateRefreshTokenCommand>
    {
        IRefreshTokenRepository _repository;

        public CreateRefreshTokenCommandHandler(IRefreshTokenRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRefreshTokenCommand command,CancellationToken cancellationToken)
        {
            if (command.token == null) return;
            var newToken = new RefreshToken
            {
                Token = command.token,
                UserId = command.userId,
                ExpiryDate = DateTime.UtcNow.AddDays(30)
            };
            await _repository.AddRefreshTokenAsync(newToken, cancellationToken);
        }
    }
}
