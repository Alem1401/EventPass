using EventPass.Application.DTOs.OrganizerDTOs;
using EventPass.Domain.Interfaces;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetByName
{
    public class GetOrganizersByNameQueryHandler : IRequestHandler<GetOrganizersByNameQuery, IEnumerable<OrganizerResponseDto>>
    {
        private readonly IOrganizerRepository _organizerRepository;

        public GetOrganizersByNameQueryHandler(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<IEnumerable<OrganizerResponseDto>> Handle(GetOrganizersByNameQuery request, CancellationToken cancellationToken)
        {
            var organizers = await _organizerRepository.GetByNameAsync(request.Name, cancellationToken);

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
