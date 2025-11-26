using EventPass.Application.DTOs.CartDTOs;
using MediatR;

namespace EventPass.Application.Queries.Carts.GetAll
{
    public class GetAllCartsQuery: IRequest<IEnumerable<ResponseCartDto>>
    {
    }
}
