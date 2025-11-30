using EventPass.Domain.Entities.Orders;

namespace EventPass.Domain.Entities.Payments { 

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; }
    public bool Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public int? OrderID { get; set; }
    public Order? Order { get; set; }
}

}