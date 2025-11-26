using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Tickets.GetByEvent
{
    public class GetTicketsByEventQueryHandler : IRequestHandler<GetTicketsByEventQuery, IEnumerable<ResponseTicketDTO>>
    {
        ITicketRepository _repository;
        public GetTicketsByEventQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseTicketDTO>> Handle(GetTicketsByEventQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _repository.GetAllTicketsAsync(cancellationToken);
            var filteredTickets = tickets.Where(t => t.TicketType.EventID == request.EventId);
            return filteredTickets.Select(t => new ResponseTicketDTO
            {
                Id = t.Id,
                ticketTypeId = t.TicketTypeID,
                UserId = t.UserID,

            });
        }
    }
}
