namespace EventPass.Application.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public DateTime orderDate {  get; set; }
        public decimal totalAmount { get; set; }
        public bool paymentStatus { get; set; }
        public string paymentMethod { get; set; }
        public string billingAdress { get; set; }
        public string shippingAdress { get; set; }
        public int transactionNumber { get; set; }
        public int userID { get; set; }
    }
}
