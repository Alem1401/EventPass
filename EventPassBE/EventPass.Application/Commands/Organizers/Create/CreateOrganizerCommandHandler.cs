using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Domain.Entities.Organizers;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Commands.Organizers.Create
{
    public class CreateOrganizerCommandHandler : IRequestHandler<CreateOrganizerCommand, OrganizerResponseDto>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public CreateOrganizerCommandHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<OrganizerResponseDto> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
        {
            var organizer = new Organizer
            {
                Name = request.OrganizerDto.Name,
                LogoUrl = request.OrganizerDto.LogoUrl,
                Email = request.OrganizerDto.Email,
                Telephone = request.OrganizerDto.Telephone,
                Website = request.OrganizerDto.Website,
                City = request.OrganizerDto.City,
                Country = request.OrganizerDto.Country
            };

            var createdOrganizer = await _organizerRepository.AddAsync(organizer, cancellationToken);

            return new OrganizerResponseDto
            {
                Id = createdOrganizer.Id,
                Name = createdOrganizer.Name,
                LogoUrl = createdOrganizer.LogoUrl,
                Email = createdOrganizer.Email,
                Telephone = createdOrganizer.Telephone,
                Website = createdOrganizer.Website,
                City = createdOrganizer.City,
                Country = createdOrganizer.Country
            };
        }
    }
}