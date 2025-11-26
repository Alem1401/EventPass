using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.Orders.GetById
{
    public class GetOrderByIdQuery: IRequest<ResponseOrderDto>
    {
        public int Id { get; set; }
    }
}
