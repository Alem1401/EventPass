
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.Users;

namespace EventPass.Application.DTOs.OrderDTOs
{
    public class ResponseOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingAdress { get; set; }
        public string ShippingAdress { get; set; }
        public int TransactionNumber { get; set; }
        public int UserId { get; set; }
    }
}
