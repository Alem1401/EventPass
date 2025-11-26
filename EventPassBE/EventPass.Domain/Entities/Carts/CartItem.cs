using EventPass.Domain.Entities.Carts;
using EventPass.Domain.Entities.Tickets;

namespace EventPass.Domain.Entities.CartItems
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId{ get; set; }
        public Cart Cart { get; set; }
        public int TicketID { get; set; }
        public Ticket Ticket { get; set; }
    }
}