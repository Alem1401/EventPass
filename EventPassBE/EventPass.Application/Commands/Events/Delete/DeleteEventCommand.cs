using MediatR;

namespace EventPass.Application.Commands.Events.Delete
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}