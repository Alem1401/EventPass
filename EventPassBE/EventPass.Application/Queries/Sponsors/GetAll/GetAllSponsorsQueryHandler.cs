using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces.Sponsors;
using EventPass.Application.Queries.Sponsors.GetAll;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetSponsors.GetAll
{
    public class GetSponsorsQueryHandler : IRequestHandler<GetAllSponsorsQuery, IEnumerable<ResponseSponsorDto>>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public GetSponsorsQueryHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<IEnumerable<ResponseSponsorDto>> Handle(GetAllSponsorsQuery request, CancellationToken cancellationToken)
        {
            var sponsors = await _sponsorRepository.GetAllAsync(cancellationToken);

            return sponsors.Select(s => new ResponseSponsorDto
            {
                Id = s.Id,
                Name = s.Name,
                LogoUrl = s.LogoUrl,
                WebsiteUrl = s.websiteUrl,
                Email = s.Email,
                Phone = s.Phone,
                EventCount = s.Events?.Count ?? 0
            });
        }
    }
}