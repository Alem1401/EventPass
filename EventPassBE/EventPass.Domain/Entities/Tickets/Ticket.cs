using EventPass.Domain.Entities.CartItems;
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Entities.Users;


namespace EventPass.Domain.Entities.Tickets
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public int UserID { get; set; }
        public int TicketTypeID { get; set; }
        public User User { get; set; }
        public TicketType TicketType { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
