using Application.Features.Finance.MovementTypes.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.MovementTypes.Commands.Delete;

public class DeleteMovementTypeCommandValidator:AbstractValidator<DeleteMovementTypeCommand>
{
    public DeleteMovementTypeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(LH.Get(MovementTypeMessages.MovementTypeIdGreaterThanZero));
    }
}
