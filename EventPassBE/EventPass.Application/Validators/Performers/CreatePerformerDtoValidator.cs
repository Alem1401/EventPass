using EventPass.Application.DTOs.PerformerDTOs;
using FluentValidation;

namespace EventPass.Application.Validators.Performers
{
    public class CreatePerformerDtoValidator : AbstractValidator<CreatePerformerDto>
    {
        public CreatePerformerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must have at least 2 characters.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.ImageURL)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Image URL must be a valid URL.");

            RuleFor(x => x.Website)
                .Must(uri => string.IsNullOrWhiteSpace(uri) || Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Website must be a valid URL.");

            RuleForEach(x => x.SocialMedia)
                .SetValidator(new CreateSocialMediaDtoValidator());

            RuleFor(x => x.SocialMedia)
                .Must(list => list.Select(sm => sm.Link.ToLower()).Distinct().Count() == list.Count)
                .WithMessage("Duplicate social media links are not allowed.");
        }
    }
}
