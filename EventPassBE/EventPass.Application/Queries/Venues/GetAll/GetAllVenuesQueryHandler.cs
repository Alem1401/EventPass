using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;

namespace EventPass.Application.Queries.Venues.GetAll
{
    public class GetAllVenuesQueryHandler : IRequestHandler<GetAllVenuesQuery, List<ResponseVenueDto>>
    {
        IVenueRepository _repository;

        public GetAllVenuesQueryHandler(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseVenueDto>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
        {
            var venues = await _repository.GetAllVenuesAsync(cancellationToken);
            var response = new List<ResponseVenueDto>();
            foreach (var item in venues)
            {
                response.Add(new ResponseVenueDto { 
                    Id = item.Id,
                    Adress = item.Adress,
                    Capacity = item.Capacity,
                    City = item.City,
                    Country = item.Country,
                    Name = item.Name,
                    PostalCode = item.PostalCode,
                    venueType = item.VenueType.Name });
            }

            return response;
        }
    }
}
