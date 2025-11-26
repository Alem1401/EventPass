using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Queries.Reviews.GetById
{
    public class GetReviewByIdQuery : IRequest<ResponseReviewDto>
    {
        public int Id { get; set; }
    }
}