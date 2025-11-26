using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Commands.OrderItems.Create
{
    public class CreateOrderItemCommand : IRequest<ResponseOrderItemDto>
    {
        public CreateOrderItemDto dto { get; set; }
    }
}
