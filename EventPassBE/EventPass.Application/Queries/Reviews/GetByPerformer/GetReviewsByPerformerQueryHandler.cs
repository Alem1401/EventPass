using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Application.Queries.Reviews;
using EventPass.Application.Queries.Reviews.GetByPerformer;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.GetByPerformer
{
    public class GetReviewsByPerformerQueryHandler : IRequestHandler<GetReviewsByPerformerQuery, IEnumerable<ResponseReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewsByPerformerQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<ResponseReviewDto>> Handle(GetReviewsByPerformerQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetByPerformerIdAsync(request.PerformerId, cancellationToken);
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