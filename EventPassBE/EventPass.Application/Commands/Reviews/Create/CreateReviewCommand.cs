using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Commands.Reviews.Create
{
    public class CreateReviewCommand : IRequest<ResponseReviewDto>
    {
        public CreateReviewDto ReviewDto { get; set; }
    }
}