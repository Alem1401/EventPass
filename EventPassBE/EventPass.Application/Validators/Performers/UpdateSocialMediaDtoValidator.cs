using EventPass.Application.DTOs.PerformerDTOs;
using FluentValidation;

namespace EventPass.Application.Validators.Performers
{
    public class UpdateSocialMediaDtoValidator : AbstractValidator<UpdateSocialMediaDto>
    {
        public UpdateSocialMediaDtoValidator()
        {
            RuleFor(x => x.Link)
                .NotEmpty().WithMessage("Link is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Link must be a valid URL.")
                .MaximumLength(300);

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .When(x => x.Id.HasValue)
                .WithMessage("Id must be greater than zero if provided.");
        }
    }
}
