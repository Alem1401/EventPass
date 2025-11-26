using FluentValidation;
using EventPass.Application.Commands.Events.Delete;

namespace EventPass.Application.Validators.Events
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Event ID must be valid");
        }
    }
}