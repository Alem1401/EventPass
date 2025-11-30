using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Queries.CartItems.GetAll
{
    public class GetAllCartItemsQueryHandler: IRequestHandler<GetAllCartItemsQuery, IEnumerable<ResponseCartItemDto>>
    {
        ICartItemsRepository _repository;

        public GetAllCartItemsQueryHandler(ICartItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseCartItemDto>> Handle(GetAllCartItemsQuery query, CancellationToken cancellationToken)
        {
            var cartItems = await _repository.GetAllCartItemsAsync(cancellationToken);
            if(cartItems == null) return null;

            return cartItems.Select(ci => new ResponseCartItemDto
            {
                Id = ci.Id,
                cartId = (int)ci.CartId,
                ticketId = (int)ci.TicketID
            });
        }
    }
}
