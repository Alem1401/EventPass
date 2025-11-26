using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Commands.Orders.Delete
{
    public class DeleteOrderQueryHandler : IRequestHandler<DeleteOrderQuery, bool>
    {
        IOrdersRepository _repository;

        public DeleteOrderQueryHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderQuery query, CancellationToken cancellationToken)
        {
            return await _repository.DeleteOrderAsync(query.Id, cancellationToken);
        }
    }
}
