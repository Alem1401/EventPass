using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.EventDTOs
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BannerURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int MinimumAge { get; set; }
        public int PerformerID { get; set; }
        public int CategoryId { get; set; }
        public int OrganizerID { get; set; }
    }
}
