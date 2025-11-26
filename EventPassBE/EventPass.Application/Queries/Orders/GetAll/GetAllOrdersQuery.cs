using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.Orders.GetAll
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<ResponseOrderDto>>
    {
    }
}
