using EventPass.Domain.Interfaces.Services;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Commands.Tokens.Create
{
    public class CreateJwtTokenCommandHandler: IRequestHandler<CreateJwtTokenCommand, string>
    {
        IJwtService _jwtService;
        IUserRepository _userRepository;

        public CreateJwtTokenCommandHandler(IJwtService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateJwtTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(command.userId, cancellationToken);
            return _jwtService.GenerateToken(user);
        }
    }
}
