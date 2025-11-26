using EventPass.Domain.Entities.VenueTypes;
using EventPass.Domain.Interfaces.Venues;
using MediatR;

namespace EventPass.Application.Commands.VenueTypes.Create
{
    public class CreateVenueTypeCommandHandler : IRequestHandler<CreateVenueTypeCommand, VenueType>
    {
        private readonly IVenueTypeRepository _repository;

        public CreateVenueTypeCommandHandler(IVenueTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<VenueType> Handle(CreateVenueTypeCommand request, CancellationToken cancellationToken)
        {
            var venueType = new VenueType { Name = request.Name };
            await _repository.AddVenueTypeAsync(venueType, cancellationToken);
            return venueType;
        }

    }
}
