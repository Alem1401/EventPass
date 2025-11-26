using MediatR;

namespace EventPass.Application.Commands.Venues.Delete
{
    public class DeleteVenueCommand : IRequest<bool>
    {
      public  int Id;
    }
}
