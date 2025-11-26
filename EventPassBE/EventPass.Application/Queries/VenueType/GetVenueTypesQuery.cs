using EventPass.Domain.Entities.VenueTypes;
using MediatR;
using System.Collections.Generic;

namespace EventPass.Application.VenueTypes.Queries
{
    public class GetVenueTypesQuery : IRequest<IEnumerable<VenueType>>
    {
    }
}
