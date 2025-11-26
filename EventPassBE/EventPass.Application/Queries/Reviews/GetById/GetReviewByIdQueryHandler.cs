using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Application.Queries.Reviews.GetById;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.GetById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ResponseReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ResponseReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
            if (review == null)
                return null;

            return new ResponseReviewDto
            {
                Id = review.Id,
                Rating = review.Rating,
                PerformerID = review.PerformerID,
                UserID = review.UserID,
                UserName = review.User.Name,
                PerformerName = review.Performer.Name
            };
        }
    }
}