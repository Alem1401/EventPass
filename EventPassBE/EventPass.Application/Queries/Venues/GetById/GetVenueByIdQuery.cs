using EventPass.Application.DTOs.VenueDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Venues.GetById
{
    public class GetVenueByIdQuery : IRequest<ResponseVenueDto>
    {
        public int Id;
    }
}
