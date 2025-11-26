using MediatR;

namespace EventPass.Application.Commands.OrderItems.Delete
{
    public class DeleteOrderItemCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
