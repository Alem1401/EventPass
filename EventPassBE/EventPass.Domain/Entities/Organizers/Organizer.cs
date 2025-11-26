
using EventPass.Domain.Entities.Events;


namespace EventPass.Domain.Entities.Organizers;

public class Organizer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string Website { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public ICollection<Event> Events { get; set; } = new HashSet<Event>();
}
