using EventPass.Domain.Entities.SponsorEvents;

namespace EventPass.Domain.Entities.Sponsors
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string websiteUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<SponsorEvent> Events { get; set; } = new HashSet<SponsorEvent>();
    }
}
