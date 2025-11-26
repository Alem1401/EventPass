using EventPass.Application.DTOs.ReviewDTOs;
using MediatR;

namespace EventPass.Application.Commands.Reviews.Update
{
    public class UpdateReviewCommand : IRequest<ResponseReviewDto>
    {
        public int Id { get; set; }
        public UpdateReviewDto ReviewDto { get; set; }
    }
}