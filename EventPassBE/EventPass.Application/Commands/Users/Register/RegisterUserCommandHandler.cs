using EventPass.Domain.Entities.Users;
using EventPass.Domain.Interfaces.Users;
using EventPass.Domain.Interfaces.Security;
using MediatR;

namespace EventPass.Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (existing != null) return -1;

            var (hash, salt) = _passwordHasher.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                IsActive = true,
                RegistrationDate = DateTime.Now,
                RoleID = 1
            };

            await _userRepository.AddUserAsync(user, cancellationToken);
            return user.Id;
        }
    }
}
