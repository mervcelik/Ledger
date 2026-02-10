using Application.Features.Finance.CurrentAccounts.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.CurrentAccounts.Commands.Create;

public class CreateCurrentAccountCommandValidator:AbstractValidator<CreateCurrentAccountCommand>
{
    public CreateCurrentAccountCommandValidator()
    {
        RuleFor(x=>x.Name).NotEmpty().WithMessage(LH.Get(CurrentAccountMessages.CANameNotNull));
        RuleFor(x=>x.TaxNumber).NotEmpty().WithMessage(LH.Get(CurrentAccountMessages.CATaxNumberNotNull));
        RuleFor(x=>x.CompanyId).GreaterThan(0).WithMessage(LH.Get(CurrentAccountMessages.CACompanyIdNotNull));
    }
}