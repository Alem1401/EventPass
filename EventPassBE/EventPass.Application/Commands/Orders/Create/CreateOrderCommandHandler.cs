using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Commands.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseOrderDto>
    {
        IOrdersRepository _repository;

        public CreateOrderCommandHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseOrderDto> Handle(CreateOrderCommand query, CancellationToken ct)
        {
            var newOrder = new Order
            {
                OrderDate = query.dto.orderDate,
                TotalAmount = query.dto.totalAmount,
                PaymentStatus = query.dto.paymentStatus,
                PaymentMethod = query.dto.paymentMethod,
                BillingAdress = query.dto.billingAdress,
                ShippingAdress = query.dto.shippingAdress,
                TransactionNumber = query.dto.transactionNumber,
                UserID = query.dto.userID
            };

            var createdOrder = await _repository.AddOrderAsync(newOrder, ct);

            return new ResponseOrderDto
            {
                Id = createdOrder.Id,
                OrderDate = createdOrder.OrderDate,
                TotalAmount = createdOrder.TotalAmount,
                PaymentStatus = createdOrder.PaymentStatus,
                PaymentMethod = createdOrder.PaymentMethod,
                BillingAdress = createdOrder.BillingAdress,
                ShippingAdress = createdOrder.ShippingAdress,
                TransactionNumber = createdOrder.TransactionNumber,
                UserId = (int)createdOrder.UserID
            };
        }
    }
}
