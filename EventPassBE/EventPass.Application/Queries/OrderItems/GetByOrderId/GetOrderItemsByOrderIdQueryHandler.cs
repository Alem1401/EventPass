
using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetByOrderId
{
    public class GetOrderItemsByOrderIdQueryHandler: IRequestHandler<GetOrderItemsByOrderIdQuery, IEnumerable<ResponseOrderItemDto>>
    {
        IOrderItemsRepository _repository;

        public GetOrderItemsByOrderIdQueryHandler(IOrderItemsRepository repository) {  _repository = repository; }

        public async Task<IEnumerable<ResponseOrderItemDto>> Handle(GetOrderItemsByOrderIdQuery query, CancellationToken ct)
        {
            var orderItems = await _repository.GetOrderItemsByOrderIdAsync(query.orderId, ct);
            return orderItems.Select(oi => new ResponseOrderItemDto
            {
                Id = oi.Id,
                priceAtPurchase = oi.PriceAtPurchase,
                orderID = oi.OrderID,
                ticketID = oi.TicketID
            });
        }
    }
}
