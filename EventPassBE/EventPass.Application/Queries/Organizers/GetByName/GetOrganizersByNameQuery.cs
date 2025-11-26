using EventPass.Application.DTOs.OrganizerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetByName
{
    public class GetOrganizersByNameQuery : IRequest<IEnumerable<OrganizerResponseDto>>
    {
        public string Name { get; set; }
    }
}
