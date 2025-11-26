using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Entities.Sponsors;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.Sponsors.Create
{
    public class CreateSponsorCommandHandler : IRequestHandler<CreateSponsorCommand, ResponseSponsorDto>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public CreateSponsorCommandHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<ResponseSponsorDto> Handle(CreateSponsorCommand request, CancellationToken cancellationToken)
        {
            var sponsor = new Sponsor
            {
                Name = request.SponsorDto.Name,
                LogoUrl = request.SponsorDto.LogoUrl,
                websiteUrl = request.SponsorDto.WebsiteUrl,
                Email = request.SponsorDto.Email,
                Phone = request.SponsorDto.Phone
            };

            var createdSponsor = await _sponsorRepository.AddAsync(sponsor, cancellationToken);

            return new ResponseSponsorDto
            {
                Id = createdSponsor.Id,
                Name = createdSponsor.Name,
                LogoUrl = createdSponsor.LogoUrl,
                WebsiteUrl = createdSponsor.websiteUrl,
                Email = createdSponsor.Email,
                Phone = createdSponsor.Phone,
                EventCount = 0
            };
        }
    }
}