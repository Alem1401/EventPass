using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Queries.CartItems.GetByCartId
{
    public class GetCartItemsByCartIdHandler: IRequestHandler<GetCartItemsByCartIdQuery, IEnumerable<ResponseCartItemDto>>
    {
        ICartItemsRepository _repository;

        public GetCartItemsByCartIdHandler(ICartItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseCartItemDto>> Handle(GetCartItemsByCartIdQuery query, CancellationToken cancellationToken)
        {
            var items = await _repository.GetCartItemsByCartIdAsync(query.cartId, cancellationToken);
            if (items == null) return null;

            return items.Select(i => new ResponseCartItemDto
            {
                Id = i.Id,
                cartId = i.CartId,
                ticketId = i.TicketID
            });
        }
    }
}
