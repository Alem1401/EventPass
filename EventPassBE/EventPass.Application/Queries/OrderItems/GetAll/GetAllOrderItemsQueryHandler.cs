using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetAll
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<ResponseOrderItemDto>>
    {
        IOrderItemsRepository _repository;

        public GetAllOrderItemsQueryHandler(IOrderItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseOrderItemDto>> Handle(GetAllOrderItemsQuery query, CancellationToken cancellationToken)
        {
            var orderItems = await _repository.GetAllOrderItemsAsync(cancellationToken);
            return orderItems.Select(o => new ResponseOrderItemDto
            {
                Id = o.Id,
                priceAtPurchase = o.PriceAtPurchase,
                orderID = o.OrderID,
                ticketID = o.TicketID
            });
        }
    }
}
