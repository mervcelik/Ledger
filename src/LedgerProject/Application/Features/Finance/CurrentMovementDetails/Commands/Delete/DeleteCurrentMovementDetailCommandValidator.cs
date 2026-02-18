using Application.Features.Finance.CurrentMovementDetails.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Delete;

public class DeleteCurrentMovementDetailCommandValidator : AbstractValidator<DeleteCurrentMovementDetailCommand>
{
    public DeleteCurrentMovementDetailCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.CurrentMovementMustExist));
    }
}
