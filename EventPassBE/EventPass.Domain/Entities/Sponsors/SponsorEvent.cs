using EventPass.Domain.Entities.Events;
using EventPass.Domain.Entities.Sponsors;

namespace EventPass.Domain.Entities.SponsorEvents
{
    public class SponsorEvent
    {
        public int Id { get; set; }
        public string Tier { get; set; }
        public decimal AmountSponsored { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
        public int SponsorID { get; set; }
        public Sponsor Sponsor { get; set; }

    }
}
