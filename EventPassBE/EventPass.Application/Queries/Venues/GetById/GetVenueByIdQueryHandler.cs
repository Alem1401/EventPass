using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;


namespace EventPass.Application.Queries.Venues.GetById
{
    public class GetVenueByIdQueryHandler : IRequestHandler<GetVenueByIdQuery,ResponseVenueDto>
    {
        IVenueRepository _repository;

        public GetVenueByIdQueryHandler(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseVenueDto> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
        {
            var venue =await _repository.GetVenueByIdAsync(request.Id, cancellationToken);
            if(venue == null)
            {
                return null;
            }
            else {
            var response = new ResponseVenueDto()
            {
                Id = venue.Id,
                Name = venue.Name,
                Adress = venue.Adress,
                City = venue.City,
                Country = venue.Country,
                PostalCode = venue.PostalCode,
                Capacity = venue.Capacity,
                venueType = venue.VenueType.Name
            };
            return response;
            }
        }
    }
}
