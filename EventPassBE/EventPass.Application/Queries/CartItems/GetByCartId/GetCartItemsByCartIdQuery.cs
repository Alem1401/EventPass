using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Queries.CartItems.GetByCartId
{
    public class GetCartItemsByCartIdQuery: IRequest<IEnumerable<ResponseCartItemDto>>
    {
        public int cartId { get; set; }
    }
}
