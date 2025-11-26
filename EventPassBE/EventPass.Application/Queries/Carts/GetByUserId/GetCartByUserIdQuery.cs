using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Queries.Carts.GetByUserId
{
    public class GetCartByUserIdQuery: IRequest<ResponseCartDto>
    {
        public int userId { get; set; }
    }
}
