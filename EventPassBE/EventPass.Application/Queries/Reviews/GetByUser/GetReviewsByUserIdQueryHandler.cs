using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Domain.Interfaces.Reviews;
using MediatR;

namespace EventPass.Application.Queries.Reviews.GetByUser
{
    public class GetReviewsByUserIdQueryHandler : IRequestHandler<GetReviewsByUserIdQuery, IEnumerable<ResponseReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewsByUserIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<ResponseReviewDto>> Handle(GetReviewsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            return reviews.Select(r => new ResponseReviewDto
            {
                Id = r.Id,
                Rating = r.Rating,
                PerformerID = (int)r.PerformerID,
                UserID = (int)r.UserID,
                UserName = r.User.Name,
                PerformerName = r.Performer.Name
            });
        }
    }
}