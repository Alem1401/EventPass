using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetByName
{
    public class GetSponsorsByNameQueryHandler : IRequestHandler<GetSponsorsByNameQuery, IEnumerable<ResponseSponsorDto>>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public GetSponsorsByNameQueryHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<IEnumerable<ResponseSponsorDto>> Handle(GetSponsorsByNameQuery request, CancellationToken cancellationToken)
        {
            var sponsors = await _sponsorRepository.GetByNameAsync(request.Name, cancellationToken);

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
