using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.PerformerDTOs
{
    public class UpdatePerformerDto
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Website { get; set; }
        public List<UpdateSocialMediaDto> SocialMedia { get; set; } = new();
    }
}