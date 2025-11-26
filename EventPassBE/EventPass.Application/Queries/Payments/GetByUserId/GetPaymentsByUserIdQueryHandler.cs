
using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.Payments.GetByUserId
{
    public class GetPaymentsByUserIdQueryHandler: IRequestHandler<GetPaymentsByUserIdQuery, IEnumerable<ResponsePaymentDto>>
    {
        IPaymentsRepository _repository;

        public GetPaymentsByUserIdQueryHandler(IPaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponsePaymentDto>> Handle(GetPaymentsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var payments = await _repository.GetPaymentsByUserIdAsync(query.userId, cancellationToken);

            return payments.Select(payment => new ResponsePaymentDto
            {
                Id = payment.Id,
                amount = payment.Amount,
                method = payment.Method,
                status = payment.Status,
                transactionDate = payment.TransactionDate,
                orderId = payment.OrderID
            });
        }
    }
}
