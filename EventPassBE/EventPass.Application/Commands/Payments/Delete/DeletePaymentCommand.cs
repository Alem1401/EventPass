using MediatR;

namespace EventPass.Application.Commands.Payments.Delete
{
    public class DeletePaymentCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
