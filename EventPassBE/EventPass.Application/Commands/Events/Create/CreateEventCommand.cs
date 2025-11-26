using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Commands.Events.Create
{
    public class CreateEventCommand : IRequest<ResponseEventDto>
    {
        public CreateEventDto EventDto { get; set; }
    }
}