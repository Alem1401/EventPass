using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Entities.Payments;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Commands.Payments.Create
{
    public class CreatePaymentCommandHandler: IRequestHandler<CreatePaymentCommand, ResponsePaymentDto>
    {
        IPaymentsRepository _repository;
        
        public CreatePaymentCommandHandler(IPaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponsePaymentDto> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            var newPayment = new Payment
            {
                Method = command.dto.method,
                Status = command.dto.status,
                TransactionDate = command.dto.transactionDate,
                OrderID = command.dto.orderId
            };
            var response = await _repository.AddPaymentAsync(newPayment, cancellationToken);
            return new ResponsePaymentDto
            {
                Id = response.Id,
                method = response.Method,
                status = response.Status,
                transactionDate = response.TransactionDate,
                orderId = response.OrderID
            };
        }
    }
}
