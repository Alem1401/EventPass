using MediatR;
using EventPass.Domain.Entities.VenueTypes;

namespace EventPass.Application.Commands.VenueTypes.Create
{
    public class CreateVenueTypeCommand : IRequest<VenueType>
    {
        public string Name { get; set; }
    }
}
