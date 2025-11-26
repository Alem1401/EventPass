using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.SponsorDTOs
{
    public class CreateSponsorDto
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
