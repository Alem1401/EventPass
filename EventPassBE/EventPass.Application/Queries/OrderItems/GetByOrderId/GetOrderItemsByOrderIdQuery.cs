using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetByOrderId
{
    public class GetOrderItemsByOrderIdQuery: IRequest<IEnumerable<ResponseOrderItemDto>>
    {
        public int orderId { get; set; }
    }
}
