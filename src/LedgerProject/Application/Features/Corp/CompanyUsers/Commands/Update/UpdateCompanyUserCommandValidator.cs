using Application.Features.Corp.CompanyUsers.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Corp.CompanyUsers.Commands.Update;

public class UpdateCompanyUserCommandValidator : AbstractValidator<UpdateCompanyUserCommand>
{
    public UpdateCompanyUserCommandValidator()
    {
        RuleFor(cu => cu.UserId).GreaterThan(0).WithMessage(LH.Get(CompanyUserMessages.CompanyUserUserIdNotEmpty));
        RuleFor(cu => cu.CompanyId).GreaterThan(0).WithMessage(LH.Get(CompanyUserMessages.CompanyUserCompanyIdNotEmpty));
    }
}
