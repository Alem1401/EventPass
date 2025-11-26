using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Queries.Sponsors.GetById
{
    public class GetSponsorByIdQueryHandler : IRequestHandler<GetSponsorByIdQuery, ResponseSponsorDto>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public GetSponsorByIdQueryHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<ResponseSponsorDto> Handle(GetSponsorByIdQuery request, CancellationToken cancellationToken)
        {
            var sponsor = await _sponsorRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sponsor == null)
                return null;

            return new ResponseSponsorDto
            {
                Id = sponsor.Id,
                Name = sponsor.Name,
                LogoUrl = sponsor.LogoUrl,
                WebsiteUrl = sponsor.websiteUrl,
                Email = sponsor.Email,
                Phone = sponsor.Phone,
                EventCount = sponsor.Events?.Count ?? 0
            };
        }
    }
}
