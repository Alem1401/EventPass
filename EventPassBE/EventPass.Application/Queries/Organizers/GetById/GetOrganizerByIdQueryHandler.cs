using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetById
{
    public class GetOrganizerByIdQueryHandler : IRequestHandler<GetOrganizerByIdQuery, OrganizerResponseDto>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public GetOrganizerByIdQueryHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<OrganizerResponseDto> Handle(GetOrganizerByIdQuery request, CancellationToken cancellationToken)
        {
            var organizer = await _organizerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (organizer == null)
                return null;

            return new OrganizerResponseDto
            {
                Id = organizer.Id,
                Name = organizer.Name,
                LogoUrl = organizer.LogoUrl,
                Email = organizer.Email,
                Telephone = organizer.Telephone,
                Website = organizer.Website,
                City = organizer.City,
                Country = organizer.Country
            };
        }
    }
}
