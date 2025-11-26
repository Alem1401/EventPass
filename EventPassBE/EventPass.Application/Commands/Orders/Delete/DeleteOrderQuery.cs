using MediatR;

namespace EventPass.Application.Commands.Orders.Delete
{
    public class DeleteOrderQuery: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
