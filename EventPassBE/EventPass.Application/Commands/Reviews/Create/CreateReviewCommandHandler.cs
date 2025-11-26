using EventPass.Application.Commands.Reviews;
using EventPass.Application.Commands.Reviews.Create;
using EventPass.Application.DTOs.ReviewDTOs;
using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Interfaces;
using EventPass.Domain.Interfaces.Performers;
using EventPass.Domain.Interfaces.Reviews;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Handlers.Reviews.Create
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ResponseReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPerformerRepository _performerRepository;
        private readonly IUserRepository _userRepository;

        public CreateReviewCommandHandler(
            IReviewRepository reviewRepository,
            IPerformerRepository performerRepository,
            IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _performerRepository = performerRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var performer = await _performerRepository.GetPerformerByIdAsync(request.ReviewDto.PerformerID, cancellationToken);
            var user = await _userRepository.GetUserByIdAsync(request.ReviewDto.UserID, cancellationToken);

            if (performer == null || user == null)
                throw new Exception("Performer or User not found");

            var review = new Review
            {
                Rating = request.ReviewDto.Rating,
                PerformerID = request.ReviewDto.PerformerID,
                UserID = request.ReviewDto.UserID
            };

            var createdReview = await _reviewRepository.AddAsync(review, cancellationToken);

            return new ResponseReviewDto
            {
                Id = createdReview.Id,
                Rating = createdReview.Rating,
                PerformerID = createdReview.PerformerID,
                UserID = createdReview.UserID,
                UserName = user.Name,
                PerformerName = performer.Name
            };
        }
    }
}