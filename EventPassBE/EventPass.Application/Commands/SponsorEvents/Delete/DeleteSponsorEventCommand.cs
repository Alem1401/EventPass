using MediatR;

namespace EventPass.Application.Commands.SponsorEvents.Delete
{
    public class DeleteSponsorEventCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
