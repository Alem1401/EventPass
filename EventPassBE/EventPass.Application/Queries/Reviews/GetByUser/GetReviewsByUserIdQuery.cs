using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Queries.Reviews.GetByUser
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ResponseReviewDto>>
    {
        public int UserId { get; set; }
    }
}