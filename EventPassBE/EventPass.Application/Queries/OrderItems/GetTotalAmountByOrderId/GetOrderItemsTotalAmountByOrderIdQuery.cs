using MediatR;

namespace EventPass.Application.Queries.OrderItems.GetTotalAmountByOrderId
{
    public class GetOrderItemsTotalAmountByOrderIdQuery: IRequest<decimal>
    {
        public int OrderId { get; set; }
    }
}
