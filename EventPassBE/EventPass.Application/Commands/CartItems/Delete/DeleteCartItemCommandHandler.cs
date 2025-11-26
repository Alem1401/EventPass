using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Commands.CartItems.Delete
{
    public class DeleteCartItemCommandHandler: IRequestHandler<DeleteCartItemCommand, bool>
    {
        ICartItemsRepository _repository;

        public DeleteCartItemCommandHandler(ICartItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCartItemCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeleteCartItemAsync(command.Id, cancellationToken);
        }
    }
}
