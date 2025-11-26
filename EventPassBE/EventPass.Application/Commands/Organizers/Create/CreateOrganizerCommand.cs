using EventPass.Application.DTOs.OrganizerDTOs;
using MediatR;

namespace EventPass.Application.Commands.Organizers.Create
{
    public class CreateOrganizerCommand : IRequest<OrganizerResponseDto>
    {
        public CreateOrganizerDto OrganizerDto { get; set; }
    }
}