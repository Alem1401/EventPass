using EventPass.Application.Commands.Reviews.Update;
using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Reviews;
using EventPass.Domain.Interfaces.Performers;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.Update
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ResponseReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPerformerRepository _performerRepository;
        private readonly IUserRepository _userRepository;

        public UpdateReviewCommandHandler(
            IReviewRepository reviewRepository,
            IPerformerRepository performerRepository,
            IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _performerRepository = performerRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingReview == null)
                throw new Exception("Review not found");

            existingReview.Rating = request.ReviewDto.Rating;

            var updatedReview = await _reviewRepository.UpdateAsync(existingReview, cancellationToken);
            var performer = await _performerRepository.GetPerformerByIdAsync(updatedReview.PerformerID, cancellationToken);
            var user = await _userRepository.GetUserByIdAsync(updatedReview.UserID, cancellationToken);

            return new ResponseReviewDto
            {
                Id = updatedReview.Id,
                Rating = updatedReview.Rating,
                PerformerID = updatedReview.PerformerID,
                UserID = updatedReview.UserID,
                UserName = user.Name,
                PerformerName = performer.Name
            };
        }
    }
}