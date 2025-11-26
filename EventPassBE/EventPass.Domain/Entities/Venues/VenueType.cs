using EventPass.Domain.Entities.Venues;

namespace EventPass.Domain.Entities.VenueTypes
{
    public class VenueType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Venue> Venues { get; set; } = new HashSet<Venue>();
    }
}
