using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.Orders.GetAll
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<ResponseOrderDto>>
    {
        IOrdersRepository _repository;
        IOrderItemsRepository _orderItemsRepository;

        public GetAllOrdersQueryHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseOrderDto>> Handle(GetAllOrdersQuery query, CancellationToken ct)
        {
            var orders = await _repository.GetAllOrdersAsync(ct);

            return orders.Select( order => new ResponseOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                PaymentMethod = order.PaymentMethod,
                BillingAdress = order.BillingAdress,
                ShippingAdress = order.ShippingAdress,
                TransactionNumber = order.TransactionNumber,
                UserId = order.UserID                
            });
        }
    }
}
