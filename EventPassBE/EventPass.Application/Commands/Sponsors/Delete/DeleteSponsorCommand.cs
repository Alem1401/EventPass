using MediatR;

namespace EventPass.Application.Commands.Sponsors.Delete
{
    public class DeleteSponsorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}