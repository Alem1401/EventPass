using EventPass.Domain.Entities.EventCategories;
using EventPass.Domain.Entities.Organizers;
using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Entities.SponsorEvents;
using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Entities.Venues;


namespace EventPass.Domain.Entities.Events { 
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BannerURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int MinimumAge { get; set; }
        public int? PerformerID { get; set; }
        public Performer? Performer { get; set; }
        public int? CategoryId { get; set; }
        public EventCategory? Category { get; set; }
        public int? OrganizerID { get; set; }
        public Organizer? Organizer { get; set; }
        public ICollection<SponsorEvent> Sponsors { get; set; } = new HashSet<SponsorEvent>();
        public int? VenueId { get; set; }
        public Venue? Venue  { get; set; }
        public ICollection<TicketType> TicketTypes { get; set; } = new HashSet<TicketType>();
    }
}