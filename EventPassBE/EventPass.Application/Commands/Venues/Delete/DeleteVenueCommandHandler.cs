using MediatR;
using EventPass.Domain.Interfaces.Venues;

namespace EventPass.Application.Commands.Venues.Delete
{
    public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand,bool>
    {
        IVenueRepository _repository;

        public DeleteVenueCommandHandler(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
        {
            var findVenue = await _repository.GetVenueByIdAsync(request.Id,cancellationToken);
            if (findVenue == null)
            {
                return false;
            }
          var response = await  _repository.DeleteVenueAsync(findVenue,cancellationToken);
            return true;
        }
    }
}
