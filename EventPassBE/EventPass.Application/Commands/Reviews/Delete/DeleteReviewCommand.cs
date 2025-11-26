using MediatR;

namespace EventPass.Application.Commands.Reviews.Delete
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}