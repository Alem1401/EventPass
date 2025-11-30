using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Interfaces.Orders;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;

namespace EventPass.Application.Commands.OrderItems.Create
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ResponseOrderItemDto>
    {
        IOrderItemsRepository _repository;
        ITicketRepository _ticketRepository;
        ITicketTypeRepository _ticketTypeRepository;

        public CreateOrderItemCommandHandler(IOrderItemsRepository repository, ITicketRepository ticketRepository, ITicketTypeRepository ticketTypeRepository)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _ticketTypeRepository = ticketTypeRepository;
        }

        public async Task<ResponseOrderItemDto> Handle(CreateOrderItemCommand command, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(command.dto.ticketID, cancellationToken);
            var ticketType = await _ticketTypeRepository.GetTicketTypeByIdAsync((int)ticket.TicketTypeID, cancellationToken);
            var newOrderItem = new OrderItem
            {
                PriceAtPurchase = ticketType.Price,
                OrderID = command.dto.orderID,
                TicketID = command.dto.ticketID
            };

            var response = await _repository.AddOrderItemAsync(newOrderItem, cancellationToken);
            return new ResponseOrderItemDto
            {
                Id = response.Id,
                priceAtPurchase = response.PriceAtPurchase,
                orderID = (int)response.OrderID,
                ticketID = (int)response.TicketID
            };
        }
    }
}
