

using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.Users;

namespace EventPass.Domain.Entities.Orders;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public bool PaymentStatus { get; set; }
    public string PaymentMethod { get; set; }
    public string BillingAdress { get; set; }
    public string ShippingAdress { get; set; }
    public int TransactionNumber { get; set; }
    public int? UserID { get; set; }
    public User? User { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
}
