using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Entities.Tickets;


namespace EventPass.Domain.Entities.OrderItems;

public class OrderItem
{
    public int Id { get; set; }
    public decimal PriceAtPurchase { get; set; }
    public int OrderID { get; set; }
    public Order Order { get; set; }
    public int TicketID { get; set; }
    public Ticket Ticket { get; set; }
}
