using EventPass.Application.DTOs.TicketDTOs;
using MediatR;


namespace EventPass.Application.Queries.Tickets.GetByEvent
{
    public class GetTicketsByEventQuery : IRequest<IEnumerable<ResponseTicketDTO>>
    {
        public int EventId { get; set; }
    }
}
