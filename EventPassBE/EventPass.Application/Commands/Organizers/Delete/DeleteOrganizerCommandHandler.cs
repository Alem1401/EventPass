using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.Organizers.Delete
{
    public class DeleteOrganizerCommandHandler : IRequestHandler<DeleteOrganizerCommand, bool>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public DeleteOrganizerCommandHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<bool> Handle(DeleteOrganizerCommand request, CancellationToken cancellationToken)
        {
            var organizer = await _organizerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (organizer == null)
                return false;

            await _organizerRepository.DeleteAsync(organizer, cancellationToken);
            return true;
        }
    }
}