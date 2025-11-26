using FluentValidation;
using EventPass.Application.Commands.Events.Update;
using EventPass.Application.Validators.Events;

namespace EventPass.Application.Validators.Events
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Event ID must be valid");

            RuleFor(x => x.EventDto)
                .NotNull().WithMessage("Event data is required")
                .SetValidator(new UpdateEventDtoValidator());
        }
    }
}