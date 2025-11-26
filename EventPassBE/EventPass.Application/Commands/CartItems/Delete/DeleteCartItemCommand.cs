using MediatR;

namespace EventPass.Application.Commands.CartItems.Delete
{
    public class DeleteCartItemCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
