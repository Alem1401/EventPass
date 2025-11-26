using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;


namespace EventPass.Application.Commands.Venues.Update
{
    public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, ResponseVenueDto>
    {
        private readonly IVenueRepository _repository;

        public UpdateVenueCommandHandler(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseVenueDto> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _repository.GetVenueByIdAsync(request.Id,cancellationToken);
            if (toUpdate == null)
            {
                throw new Exception("Venue not found");
            }
            toUpdate.Name = request.updateVenueDto.Name;
            toUpdate.Adress = request.updateVenueDto.Adress;
            toUpdate.City = request.updateVenueDto.City;
            toUpdate.Country = request.updateVenueDto.Country;
            toUpdate.PostalCode = request.updateVenueDto.PostalCode;
            toUpdate.Capacity = request.updateVenueDto.Capacity;
            toUpdate.VenueTypeID = request.updateVenueDto.VenueTypeID;
            var updatedVenue = await _repository.UpdateVenueAsync(toUpdate, cancellationToken);
            var venueWithType =  await _repository.GetVenueByIdAsync(updatedVenue.Id, cancellationToken);

            return new ResponseVenueDto
            {
                Name = venueWithType.Name,
                Adress = venueWithType.Adress,
                City  = venueWithType.City,
                Country = venueWithType.Country,
                PostalCode = venueWithType.PostalCode,
                Capacity = venueWithType.Capacity,
                venueType = venueWithType.VenueType.Name
            };
        }
    }
}
