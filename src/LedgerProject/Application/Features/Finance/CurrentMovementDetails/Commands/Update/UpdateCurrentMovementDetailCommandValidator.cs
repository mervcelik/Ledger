using Application.Features.Finance.CurrentMovementDetails.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Update;

public class UpdateCurrentMovementDetailCommandValidator : AbstractValidator<UpdateCurrentMovementDetailCommand>
{
    public UpdateCurrentMovementDetailCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.CurrentMovementMustExist));
        RuleFor(x => x.Description).NotEmpty().WithMessage(LH.Get(CurrentMovementDetailMessages.DescriptionCannotBeEmpty));
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.QuantityMustBeGreaterThanZero));
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.AmountMustBeGreaterThanZero));
        RuleFor(x => x.TaxPercient).InclusiveBetween(0, 100).WithMessage(LH.Get(CurrentMovementDetailMessages.TaxPercentMustBeValid));
        RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.TotalAmountMustBeGreaterThanZero));
    }
}
