using EventPass.Application.DTOs.Users;
using EventPass.Domain.Interfaces.Users;
using EventPass.Domain.Interfaces.Security;
using MediatR;

namespace EventPass.Application.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseUserDto>
    {
        IUserRepository _repository;
        IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseUserDto> Handle(UpdateUserCommand user, CancellationToken ct)
        {
            var userToUpdate = await _repository.GetUserByIdAsync(user.id, ct);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }
            var (hash, salt) = _passwordHasher.HashPassword(user.dto.Password);

            userToUpdate.Name = user.dto.Name;
            userToUpdate.Surname = user.dto.Surname;
            userToUpdate.PasswordSalt = salt;
            userToUpdate.PasswordHash = hash;
            await _repository.UpdateUserAsync(userToUpdate, ct);

            return new ResponseUserDto
            {
                Name = userToUpdate.Name,
                Surname = userToUpdate.Surname,
                Email = userToUpdate.Email,
            };
        }
    }
}
