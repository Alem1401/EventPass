using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Commands.CartItems.Create
{
    public class CreateCartItemCommand: IRequest<ResponseCartItemDto>
    {
        public CreateCartItemDto dto { get; set; }
    }
}
