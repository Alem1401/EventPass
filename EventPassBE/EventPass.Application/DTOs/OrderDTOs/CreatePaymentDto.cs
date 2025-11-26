namespace EventPass.Application.DTOs.OrderDTOs
{
    public class CreatePaymentDto
    {
        public string method { get; set; }
        public bool status { get; set; }
        public DateTime transactionDate { get; set; }
        public int orderId { get; set; }
    }
}
