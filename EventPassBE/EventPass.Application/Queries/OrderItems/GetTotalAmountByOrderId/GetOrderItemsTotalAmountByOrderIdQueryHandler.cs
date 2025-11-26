using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetTotalAmountByOrderId
{
    public class GetOrderItemsTotalAmountByOrderIdQueryHandler: IRequestHandler<GetOrderItemsTotalAmountByOrderIdQuery, decimal>
    {
        IOrderItemsRepository _repository;

        public GetOrderItemsTotalAmountByOrderIdQueryHandler(IOrderItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Handle(GetOrderItemsTotalAmountByOrderIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetTotalAmountByOrderId(query.OrderId, cancellationToken);
        }
    }
}
