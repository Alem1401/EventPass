using EventPass.Application.DTOs.TicketDTOs;
using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Tickets.GetAll
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<ResponseTicketDTO>>
    {
        public ITicketRepository _repository;

        public GetAllTicketsQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ResponseTicketDTO>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _repository.GetAllTicketsAsync(cancellationToken);
            return tickets.Select(t => new ResponseTicketDTO
            {
                Id = t.Id,
                ticketTypeId = (int)t.TicketTypeID,
                UserId = (int)t.UserID,

            });
        }
    }
}
