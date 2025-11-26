using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Tickets.Create
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ResponseTicketDTO>
    {
        ITicketRepository _repository;
        public CreateTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseTicketDTO> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var newTicket = new Ticket { UserID = request.UserId, TicketTypeID = request.TicketTypeId };
            newTicket.TicketNumber = new Random().Next(100000, 999999);

            var addedTicket = await _repository.AddTicketAsync(newTicket, cancellationToken);

            return new ResponseTicketDTO
            {
                Id = addedTicket.Id,
                ticketNumber = addedTicket.TicketNumber,
                UserId = addedTicket.UserID,
                ticketTypeId = addedTicket.TicketTypeID
            };
        }
    }
}
