using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Entities.Users;

namespace EventPass.Domain.Entities.Performers;

public class Review
{
        public int Id { get; set; }
        public int Rating { get; set; }
        public int? PerformerID { get; set; }
        public Performer? Performer { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
}
