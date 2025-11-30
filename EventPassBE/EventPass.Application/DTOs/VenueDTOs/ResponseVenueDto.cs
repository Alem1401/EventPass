using EventPass.Domain.Entities.VenueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.VenueDTOs
{
    public class ResponseVenueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int Capacity { get; set; }
        public string venueType { get; set; }
    }
}
