using Application.Features.Finance.CurrentMovements.Constans;
using Application.Services.Localization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Commands.Create;

public class CreateCurrentMovementCommandValidator : AbstractValidator<CreateCurrentMovementCommand>
{
    public CreateCurrentMovementCommandValidator()
    {
        RuleFor(cm => cm.CurrentAccountId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.CurrentAccountMustExist));
        RuleFor(cm => cm.AccountingPeriodId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.AccountingPeriodMustExist));
        RuleFor(cm => cm.CompanyId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.CompanyMustExist));
        RuleFor(cm => cm.MovementTypeId).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.MovementTypeMustExist));
        RuleFor(cm => cm.Description).NotEmpty().WithMessage(LH.Get(CurrentMovementMessages.DescriptionCannotBeEmpty));
        RuleFor(cm => cm.Amount).GreaterThan(0).WithMessage(LH.Get(CurrentMovementMessages.AmountMustBeGreaterThanZero));
    }
}

