using FluentValidation;
using EventPass.Application.Commands.Events.Create;
using EventPass.Application.Validators.Events;

namespace EventPass.Application.Validators.Events
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(x => x.EventDto)
                .NotNull().WithMessage("Event data is required")
                .SetValidator(new CreateEventDtoValidator());
        }
    }
}