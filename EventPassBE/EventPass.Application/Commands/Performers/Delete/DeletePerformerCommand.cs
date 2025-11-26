using MediatR;

namespace EventPass.Application.Commands.Performers
{
    public class DeletePerformerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}