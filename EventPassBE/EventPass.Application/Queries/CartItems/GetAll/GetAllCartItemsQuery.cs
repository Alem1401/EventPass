using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Queries.CartItems.GetAll
{
    public class GetAllCartItemsQuery: IRequest<IEnumerable<ResponseCartItemDto>>
    {
    }
}
