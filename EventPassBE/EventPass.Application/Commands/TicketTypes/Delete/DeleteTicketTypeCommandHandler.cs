using EventPass.Domain.Interfaces.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.TicketTypes.Delete
{
    public class DeleteTicketTypeCommandHandler :IRequestHandler<DeleteTicketTypeCommand,bool>  
    {
        ITicketTypeRepository _ticketTypeRepository;

        public DeleteTicketTypeCommandHandler(ITicketTypeRepository ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
        }

        public async Task<bool> Handle(DeleteTicketTypeCommand request, CancellationToken cancellationToken)
        {
            var ticketType = await _ticketTypeRepository.GetTicketTypeByIdAsync(request.Id, cancellationToken);
            if (ticketType == null)
            {
                return false;
            }

            
            var hasTickets = await _ticketTypeRepository.HasRelatedTicketsAsync(request.Id, cancellationToken);
            if (hasTickets)
            {
                return false;
            }

            await _ticketTypeRepository.DeleteTicketTypeAsync(ticketType, cancellationToken);
            return true;
        }
    }
}
