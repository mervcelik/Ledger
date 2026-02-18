using Application.Features.Finance.CurrentMovementDetails.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Create;

public class CreateCurrentMovementDetailCommandValidator : AbstractValidator<CreateCurrentMovementDetailCommand>
{
    public CreateCurrentMovementDetailCommandValidator()
    {
        RuleFor(cmd => cmd.CurrentMovementId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.CurrentMovementMustExist));
        RuleFor(cmd => cmd.Description).NotEmpty().WithMessage(LH.Get(CurrentMovementDetailMessages.DescriptionCannotBeEmpty));
        RuleFor(cmd => cmd.Quantity).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.QuantityMustBeGreaterThanZero));
        RuleFor(cmd => cmd.Amount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.AmountMustBeGreaterThanZero));
        RuleFor(cmd => cmd.TaxPercient).InclusiveBetween(0, 100).WithMessage(LH.Get(CurrentMovementDetailMessages.TaxPercentMustBeValid));
        RuleFor(cmd => cmd.TotalAmount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementDetailMessages.TotalAmountMustBeGreaterThanZero));
    }
}
