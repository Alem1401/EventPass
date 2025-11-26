using EventPass.Application.DTOs.OrderDTOs;
using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Queries.Payments.GetAll
{
    public class GetAllPaymentsQueryHandler: IRequestHandler<GetAllPaymentsQuery, IEnumerable<ResponsePaymentDto>>
    {
        IPaymentsRepository _repository;

        public GetAllPaymentsQueryHandler(IPaymentsRepository repository)
        {
            _repository = repository;
        }   

        public async Task<IEnumerable<ResponsePaymentDto>> Handle(GetAllPaymentsQuery query, CancellationToken cancellationToken)
        {
            var payments = await _repository.GetAllPaymentsAsync(cancellationToken);
            return payments.Select(payment => new ResponsePaymentDto
            {
                Id = payment.Id,
                amount = payment.Order.TotalAmount,
                method = payment.Method,
                status = payment.Status,
                transactionDate = payment.TransactionDate,
                orderId = payment.OrderID
            });
        }
    }
}
