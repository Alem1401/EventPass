using MediatR;

namespace EventPass.Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
