using EventPass.Domain.Entities.Events;

namespace EventPass.Domain.Entities.EventCategories;

public class EventCategory
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public ICollection<Event> Events { get; set; } = new HashSet<Event>();
}
