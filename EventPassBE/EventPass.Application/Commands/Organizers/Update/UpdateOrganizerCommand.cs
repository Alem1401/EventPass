using EventPass.Application.DTOs.OrganizerDTOs;
using MediatR;

namespace EventPass.Application.Commands.Organizers.Update
{
    public class UpdateOrganizerCommand : IRequest<OrganizerResponseDto>
    {
        public int Id { get; set; }
        public UpdateOrganizerDto OrganizerDto { get; set; }
    }
}