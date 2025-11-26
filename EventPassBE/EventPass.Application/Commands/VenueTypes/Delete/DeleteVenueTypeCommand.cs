using MediatR;

namespace EventPass.Application.Commands.VenueTypes.Delete
{
    public class DeleteVenueTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
