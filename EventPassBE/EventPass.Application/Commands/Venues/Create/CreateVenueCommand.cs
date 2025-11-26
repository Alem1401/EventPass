using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.Venues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Commands.Venues.Create
{
    public class CreateVenueCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int Capacity { get; set; }
        public int VenueTypeID { get; set; }
    }
}
