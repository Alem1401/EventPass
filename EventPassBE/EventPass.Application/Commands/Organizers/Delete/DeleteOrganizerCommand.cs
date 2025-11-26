using MediatR;

namespace EventPass.Application.Commands.Organizers.Delete
{
    public class DeleteOrganizerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}