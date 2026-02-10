using FluentValidation;

namespace Application.Features.Finance.CurrentMovements.Commands.Update;

public class UpdateCurrentMovementCommandValidator:AbstractValidator<UpdateCurrentMovementCommand>
{
    public UpdateCurrentMovementCommandValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.Amount).GreaterThan(0);
        RuleFor(c => c.MovementTypeId).GreaterThan(0);
    }
}