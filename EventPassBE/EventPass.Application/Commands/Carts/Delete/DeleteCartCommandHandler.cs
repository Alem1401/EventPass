using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Commands.Carts.Delete
{
    public class DeleteCartCommandHandler: IRequestHandler<DeleteCartCommand, bool>
    {
        ICartsRepository _repository;

        public DeleteCartCommandHandler(ICartsRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCartAsync(command.Id, cancellationToken);
        }
    }
}
