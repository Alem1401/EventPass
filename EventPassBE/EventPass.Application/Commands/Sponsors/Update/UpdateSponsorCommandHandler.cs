using EventPass.Application.DTOs.SponsorDTOs;
using EventPass.Domain.Interfaces.Sponsors;
using MediatR;

namespace EventPass.Application.Commands.Sponsors.Update
{
    public class UpdateSponsorCommandHandler : IRequestHandler<UpdateSponsorCommand, ResponseSponsorDto>
    {
        private readonly ISponsorRepository _sponsorRepository;

        public UpdateSponsorCommandHandler(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<ResponseSponsorDto> Handle(UpdateSponsorCommand request, CancellationToken cancellationToken)
        {
            var existingSponsor = await _sponsorRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingSponsor == null)
                return null;

            existingSponsor.Name = request.SponsorDto.Name;
            existingSponsor.LogoUrl = request.SponsorDto.LogoUrl;
            existingSponsor.websiteUrl = request.SponsorDto.WebsiteUrl;
            existingSponsor.Email = request.SponsorDto.Email;
            existingSponsor.Phone = request.SponsorDto.Phone;

            var updatedSponsor = await _sponsorRepository.UpdateAsync(existingSponsor, cancellationToken);

            return new ResponseSponsorDto
            {
                Id = updatedSponsor.Id,
                Name = updatedSponsor.Name,
                LogoUrl = updatedSponsor.LogoUrl,
                WebsiteUrl = updatedSponsor.websiteUrl,
                Email = updatedSponsor.Email,
                Phone = updatedSponsor.Phone,
                EventCount = updatedSponsor.Events?.Count ?? 0
            };
        }
    }
}