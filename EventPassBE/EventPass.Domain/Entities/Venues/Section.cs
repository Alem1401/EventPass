using EventPass.Domain.Entities.TicketTypes;

namespace EventPass.Domain.Entities.Venues
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int VenueID { get; set; }
        public Venue Venue { get; set; }
        public ICollection<TicketType> TicketTypes { get; set; } = new HashSet<TicketType>();
    }
}
