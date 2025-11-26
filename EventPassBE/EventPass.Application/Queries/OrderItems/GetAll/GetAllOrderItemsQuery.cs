using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetAll
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<ResponseOrderItemDto>>
    {
    }
}
