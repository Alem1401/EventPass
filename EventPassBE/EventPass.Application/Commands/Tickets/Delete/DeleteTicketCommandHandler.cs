using EventPass.Domain.Interfaces.Tickets;
using MediatR;

namespace EventPass.Application.Commands.Tickets.Delete
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
    {
        ITicketRepository _repository;

        public DeleteTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticketToDelete = await _repository.GetTicketByIdAsync(request.TicketId, cancellationToken);

            if (ticketToDelete == null)
            {
                return false;
            }
            var result =await _repository.DeleteTicketAsync(ticketToDelete, cancellationToken);

            return result;

        }
    }
}
