using Application.Features.Finance.AccountingPeriods.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.AccountingPeriods.Commands.Create;

public class CreateAccountingPeriodCommandValidator:AbstractValidator<CreateAccountingPeriodCommand>
{
    public CreateAccountingPeriodCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(LH.Get(AccountingPeriodMessages.APNameNotNull));
        RuleFor(x => x.StartDate).NotEmpty().LessThan(x => x.EndDate).WithMessage(LH.Get(AccountingPeriodMessages.APEndDateLessThanStartDate));
        RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate).WithMessage(LH.Get(AccountingPeriodMessages.APStartDateGraterThanEndDate));
        RuleFor(x => x.CompanyId).GreaterThan(0).WithMessage(LH.Get(AccountingPeriodMessages.APCompanyIdGreaterThanZero));
    }
}