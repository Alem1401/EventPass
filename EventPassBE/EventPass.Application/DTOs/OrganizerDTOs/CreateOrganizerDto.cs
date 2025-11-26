using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.OrganizerDTOs
{
    public class CreateOrganizerDto
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
