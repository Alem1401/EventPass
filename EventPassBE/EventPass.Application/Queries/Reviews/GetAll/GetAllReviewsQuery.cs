using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Queries.Reviews.GetAll
{
    public class GetAllReviewsQuery : IRequest<IEnumerable<ResponseReviewDto>> { }
}