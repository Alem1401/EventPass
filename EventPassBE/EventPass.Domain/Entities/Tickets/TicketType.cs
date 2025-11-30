using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Entities.Events;


namespace EventPass.Domain.Entities.TicketTypes
{
    public class TicketType
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int TicketsRemaining { get; set; }
        public int TicketsSold { get; set; }
        public int? SectionID { get; set; }
        public int? EventID { get; set; }
        public Section? Section { get; set; }
        public Event? Event { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
