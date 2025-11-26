using EventPass.Application.Commands.Reviews.Delete;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.Delete
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
            if (review == null)
                return false;

            await _reviewRepository.DeleteAsync(review, cancellationToken);
            return true;
        }
    }
}