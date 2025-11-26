using EventPass.Application.DTOs.OrganizerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetAll
{
    public class GetOrganizersQuery : IRequest<IEnumerable<OrganizerResponseDto>> { }
}