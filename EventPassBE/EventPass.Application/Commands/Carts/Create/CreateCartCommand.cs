using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Commands.Carts.Create
{
    public class CreateCartCommand: IRequest<ResponseCartDto>
    {
        public CreateCartDto dto { get; set; }
    }
}
