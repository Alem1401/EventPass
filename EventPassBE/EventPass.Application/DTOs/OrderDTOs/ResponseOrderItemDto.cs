namespace EventPass.Application.DTOs.OrderDTOs
{
    public class ResponseOrderItemDto
    {
        public int Id { get; set; }
        public decimal priceAtPurchase { get; set; }
        public int orderID { get; set; }
        public int ticketID { get; set; }
    }
}
