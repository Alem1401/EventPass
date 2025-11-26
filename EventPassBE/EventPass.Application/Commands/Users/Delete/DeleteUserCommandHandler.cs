using EventPass.Application.Commands.Venues.Delete;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteUserAsync(request.Id, cancellationToken);
        }
    }
}
