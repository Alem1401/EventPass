using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Queries.Payments.GetAll
{
    public class GetAllPaymentsQuery: IRequest<IEnumerable<ResponsePaymentDto>>
    {
    }
}
