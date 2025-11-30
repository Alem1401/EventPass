using FluentValidation;
using EventPass.Application.DTOs.EventDTOs;

namespace EventPass.Application.Validators.Events
{
    public class CreateEventDtoValidator : AbstractValidator<CreateEventDto>
    {
        public CreateEventDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Event name is required")
                .MaximumLength(100).WithMessage("Event name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.BannerURL)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.BannerURL))
                .WithMessage("Banner URL must be a valid URL");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required")
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Duration is required");

            RuleFor(x => x.MinimumAge)
                .InclusiveBetween(0, 100).WithMessage("Minimum age must be between 0 and 100");

            RuleFor(x => x.PerformerID)
                .GreaterThan(0).WithMessage("Performer ID must be valid");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be valid");

            RuleFor(x => x.OrganizerID)
                .GreaterThan(0).WithMessage("Organizer ID must be valid");

            RuleFor(x => x.VenueId)
                .GreaterThan(0).WithMessage("Venue ID must be valid");
        }
    }
}