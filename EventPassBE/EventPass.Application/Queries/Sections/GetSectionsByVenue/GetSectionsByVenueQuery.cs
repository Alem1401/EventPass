using EventPass.Application.DTOs.VenueDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Sections.GetSectionsByVenue
{
    public class GetSectionsByVenueQuery : IRequest<IEnumerable<ResponseSectionDto>>
    {
        public int VenueId { get; set; }
    }
}
