using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.Organizers.Update
{
    public class UpdateOrganizerCommandHandler : IRequestHandler<UpdateOrganizerCommand, OrganizerResponseDto>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public UpdateOrganizerCommandHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<OrganizerResponseDto> Handle(UpdateOrganizerCommand request, CancellationToken cancellationToken)
        {
            var existingOrganizer = await _organizerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingOrganizer == null)
                return null;

            existingOrganizer.Name = request.OrganizerDto.Name;
            existingOrganizer.LogoUrl = request.OrganizerDto.LogoUrl;
            existingOrganizer.Email = request.OrganizerDto.Email;
            existingOrganizer.Telephone = request.OrganizerDto.Telephone;
            existingOrganizer.Website = request.OrganizerDto.Website;
            existingOrganizer.City = request.OrganizerDto.City;
            existingOrganizer.Country = request.OrganizerDto.Country;

            var updatedOrganizer = await _organizerRepository.UpdateAsync(existingOrganizer, cancellationToken);

            return new OrganizerResponseDto
            {
                Id = updatedOrganizer.Id,
                Name = updatedOrganizer.Name,
                LogoUrl = updatedOrganizer.LogoUrl,
                Email = updatedOrganizer.Email,
                Telephone = updatedOrganizer.Telephone,
                Website = updatedOrganizer.Website,
                City = updatedOrganizer.City,
                Country = updatedOrganizer.Country
            };
        }
    }
}