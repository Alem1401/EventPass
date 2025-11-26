using EventPass.Application.DTOs.EventDTOs;
using MediatR;

namespace EventPass.Application.Commands.Events.Update
{
    public class UpdateEventCommand : IRequest<ResponseEventDto>
    {
        public int Id { get; set; }
        public UpdateEventDto EventDto { get; set; }
    }
}