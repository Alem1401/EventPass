using EventPass.Application.DTOs.PerformerDTOs;
using FluentValidation;
using System.Text.RegularExpressions;

public class CreateSocialMediaDtoValidator : AbstractValidator<CreateSocialMediaDto>
{
    public CreateSocialMediaDtoValidator()
    {
        RuleFor(x => x.Link)
        .NotEmpty().WithMessage("Link is required.")
        .Must(link => Regex.IsMatch(link,
         @"^(https?://)" +           
         @"([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}" + 
         @"(:\d+)?(\/.*)?$"                    
         ))
        .WithMessage("Invalid URL format.")
        .MaximumLength(300);
    }
}
