using EventPass.Application.DTOs.Users;
using EventPass.Domain.Entities.Token;
using EventPass.Domain.Interfaces.Security;
using EventPass.Domain.Interfaces.Services;
using EventPass.Domain.Interfaces.Tokens;
using EventPass.Domain.Interfaces.Users;
using MediatR;
using System.Security.Cryptography;

namespace EventPass.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler: IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        IPasswordHasher _hasher;
        IUserRepository _repository;
        IRefreshTokenRepository _refreshTokenRepository;
        IJwtService _jwtService;

        public LoginUserCommandHandler(IPasswordHasher hasher, IUserRepository repository, IJwtService jwtService, IRefreshTokenRepository refreshTokenRepository)
        {
            _hasher = hasher;
            _repository = repository;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAsync(command.Email, cancellationToken);
            if (user == null) return null;
            if(!_hasher.VerifyPassword(command.Password, user.PasswordHash, user.PasswordSalt)) return null;
            var token = _jwtService.GenerateToken(user);
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var newRefreshToken = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(30)
            };
            await _refreshTokenRepository.AddRefreshTokenAsync(newRefreshToken, cancellationToken);

            return new LoginResponseDto
            {
                jwtToken = token,
                refreshToken = refreshToken,
                email = user.Email,
                name = user.Name,
                surname = user.Surname
            };
        }
    }
}
