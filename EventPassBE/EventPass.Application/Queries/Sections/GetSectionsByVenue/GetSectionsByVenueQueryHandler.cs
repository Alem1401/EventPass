using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Interfaces.Venues;
using MediatR;

namespace EventPass.Application.Queries.Sections.GetSectionsByVenue
{
    public class GetSectionsByVenueQueryHandler : IRequestHandler<GetSectionsByVenueQuery, IEnumerable<ResponseSectionDto>>
    {
        ISectionRepository _sectionRepository;
        IVenueRepository _venueRepository;

        public GetSectionsByVenueQueryHandler(ISectionRepository sectionRepository, IVenueRepository venueRepository)
        {
            _sectionRepository = sectionRepository;
            _venueRepository = venueRepository;
        }
        public async Task<IEnumerable<ResponseSectionDto>> Handle(GetSectionsByVenueQuery request, CancellationToken cancellationToken)
        {
            var venues =await _venueRepository.GetAllVenuesAsync(cancellationToken);
            var exists = venues.Any(v => v.Id == request.VenueId);

            if (exists)
            {
                var sections = await _sectionRepository.GetSectionsByVenueAsync(request.VenueId, cancellationToken);

                return sections.Select(s => new ResponseSectionDto
                {
                    Name = s.Name,
                    Capacity = s.Capacity,
                    Id= s.Id
                });
            }
            else return null;

        }
    }
}
