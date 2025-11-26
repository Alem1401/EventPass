using EventPass.Domain.Interfaces.Venues;
using MediatR;

namespace EventPass.Application.Commands.VenueTypes.Delete
{
    public class DeleteVenueTypeCommandHandler : IRequestHandler<DeleteVenueTypeCommand, bool>
    {
        IVenueTypeRepository _repository;

        public DeleteVenueTypeCommandHandler(IVenueTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteVenueTypeCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.DeleteVenueTypeAsync(request.Id,cancellationToken)) {
                return true; 
            }
            return false; 
        }
    }
}
