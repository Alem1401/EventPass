

using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Commands.OrderItems.Delete
{
    public class DeleteOrderItemCommandHandler: IRequestHandler<DeleteOrderItemCommand, bool>
    {
        IOrderItemsRepository _repository;

        public DeleteOrderItemCommandHandler(IOrderItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderItemCommand command, CancellationToken ct)
        {
            return await _repository.DeleteOrderItemAsync(command.Id, ct);
        }
    }
}
