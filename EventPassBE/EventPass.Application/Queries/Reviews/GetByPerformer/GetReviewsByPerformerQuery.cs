using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Queries.Reviews.GetByPerformer
{
    public class GetReviewsByPerformerQuery : IRequest<IEnumerable<ResponseReviewDto>>
    {
        public int PerformerId { get; set; }
    }
}