using EventPass.Application.DTOs.OrderDTOs;
using MediatR;

namespace EventPass.Application.Commands.Payments.Create
{
    public class CreatePaymentCommand: IRequest<ResponsePaymentDto>
    {
        public CreatePaymentDto dto { get; set; }
    }
}
