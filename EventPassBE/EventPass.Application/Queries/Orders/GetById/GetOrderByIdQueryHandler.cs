using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.Orders.GetById
{
    public class GetOrderByIdQueryHandler: IRequestHandler<GetOrderByIdQuery, ResponseOrderDto>
    {
        IOrdersRepository _repository;

        public GetOrderByIdQueryHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseOrderDto> Handle(GetOrderByIdQuery query, CancellationToken ct)
        {
            var order = await _repository.GetOrderByIdAsync(query.Id, ct);
            if (order == null) return null;
            return new ResponseOrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                PaymentMethod = order.PaymentMethod,
                BillingAdress = order.BillingAdress,
                ShippingAdress = order.ShippingAdress,
                TransactionNumber = order.TransactionNumber,
                UserId = (int)order.UserID
            };
        }
    }
}
