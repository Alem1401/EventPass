using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.Events.Delete
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if (@event == null)
                return false;

        await _eventRepository.DeleteAsync(@event, cancellationToken);
            return true;
        }
    }
}