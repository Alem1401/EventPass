namespace EventPass.Application.DTOs.OrderDTOs
{
    public class ResponsePaymentDto
    {
        public int Id { get; set; }
        public decimal amount { get; set; }
        public string method { get; set; }
        public bool status { get; set; }
        public DateTime transactionDate { get; set; }
        public int orderId { get; set; }
    }
}
