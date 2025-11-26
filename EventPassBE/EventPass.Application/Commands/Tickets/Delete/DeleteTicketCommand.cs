
using MediatR;

namespace EventPass.Application.Commands.Tickets.Delete
{
    public class DeleteTicketCommand : IRequest<bool>
    {
        public int TicketId { get; set; }
    }
}
