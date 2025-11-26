using EventPass.Application.DTOs.OrganizerDTOs;
using MediatR;

namespace EventPass.Application.Queries.Organizers.GetById
{
    public class GetOrganizerByIdQuery : IRequest<OrganizerResponseDto>
    {
        public int Id { get; set; }
    }
}