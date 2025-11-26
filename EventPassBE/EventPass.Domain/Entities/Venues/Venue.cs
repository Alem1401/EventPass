using EventPass.Domain.Entities.VenueTypes;

namespace EventPass.Domain.Entities.Venues
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int Capacity { get; set; }
        public int VenueTypeID { get; set; }
        public VenueType VenueType { get; set; }
        public ICollection<Section> Sections { get; set; } = new HashSet<Section>();
    }
}
