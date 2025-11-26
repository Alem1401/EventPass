using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Entities.CartItems;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Commands.CartItems.Create
{
    public class CreateCartItemCommandHandler: IRequestHandler<CreateCartItemCommand, ResponseCartItemDto>
    {
        ICartItemsRepository _repository;

        public CreateCartItemCommandHandler(ICartItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseCartItemDto> Handle(CreateCartItemCommand command, CancellationToken cancellationToken)
        {
            var newCartItem = new CartItem
            {
                CartId = command.dto.cartId,
                TicketID = command.dto.ticketId
            };

            var response = await _repository.AddCartItemAsync(newCartItem, cancellationToken);
            return new ResponseCartItemDto
            {
                Id = response.Id,
                cartId = response.CartId,
                ticketId = response.TicketID
            };
        }
    }
}
