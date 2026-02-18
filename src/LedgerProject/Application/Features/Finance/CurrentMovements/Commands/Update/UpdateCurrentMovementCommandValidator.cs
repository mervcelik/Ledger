using Application.Features.Finance.CurrentMovements.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.CurrentMovements.Commands.Update;

public class UpdateCurrentMovementCommandValidator:AbstractValidator<UpdateCurrentMovementCommand>
{
    public UpdateCurrentMovementCommandValidator()
    {
        RuleFor(c => c.Description).NotEmpty().WithMessage(LH.Get(CurrentMovementMessages.DescriptionCannotBeEmpty));
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.Amount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.AmountMustBeGreaterThanZero));
        RuleFor(c => c.MovementTypeId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.MovementTypeMustExist));
    }
}
