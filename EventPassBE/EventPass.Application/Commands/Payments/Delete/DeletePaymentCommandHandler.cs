using EventPass.Domain.Interfaces.Orders;
using MediatR;

namespace EventPass.Application.Commands.Payments.Delete
{
    public class DeletePaymentCommandHandler: IRequestHandler<DeletePaymentCommand, bool>
    {
        IPaymentsRepository _repository;
        
        public DeletePaymentCommandHandler(IPaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            return await _repository.DeletePaymentAsync(command.Id, cancellationToken);
        }
    }
}
