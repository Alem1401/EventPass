using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.Payments.GetByUserId
{
    public class GetPaymentsByUserIdQuery: IRequest<IEnumerable<ResponsePaymentDto>>
    {
        public int userId { get; set; }
    }
}
