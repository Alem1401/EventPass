using MediatR;

namespace EventPass.Application.Commands.Carts.Delete
{
    public class DeleteCartCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
