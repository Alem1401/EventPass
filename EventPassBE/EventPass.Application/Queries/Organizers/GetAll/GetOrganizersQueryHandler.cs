using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Application.Queries.Organizers;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetAll
{
    public class GetOrganizersQueryHandler : IRequestHandler<GetOrganizersQuery, IEnumerable<OrganizerResponseDto>>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public GetOrganizersQueryHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<IEnumerable<OrganizerResponseDto>> Handle(GetOrganizersQuery request, CancellationToken cancellationToken)
        {
            var organizers = await _organizerRepository.GetAllAsync(cancellationToken);

            return organizers.Select(o => new OrganizerResponseDto
            {
                Id = o.Id,
                Name = o.Name,
                LogoUrl = o.LogoUrl,
                Email = o.Email,
                Telephone = o.Telephone,
                Website = o.Website,
                City = o.City,
                Country = o.Country
            });
        }
    }
}
