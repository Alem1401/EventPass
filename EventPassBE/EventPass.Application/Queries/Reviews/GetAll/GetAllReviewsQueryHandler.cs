using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Application.Queries.Reviews.GetAll;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.GetAll
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<ResponseReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetAllReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<ResponseReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetAllAsync(cancellationToken);
            return reviews.Select(r => new ResponseReviewDto
            {
                Id = r.Id,
                Rating = r.Rating,
                PerformerID = r.PerformerID,
                UserID = r.UserID,
                UserName = r.User.Name,
                PerformerName = r.Performer.Name
            });
        }
    }
}