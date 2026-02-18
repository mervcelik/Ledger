using Application.Features.Corp.CompanyUsers.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Corp.CompanyUsers.Commands.Delete;

public class DeleteCompanyUserCommandValidator : AbstractValidator<DeleteCompanyUserCommand>
{
    public DeleteCompanyUserCommandValidator()
    {
        RuleFor(cu => cu.Id).GreaterThan(0).WithMessage(LH.Get(CompanyUserMessages.CompanyUserIdGreaterThanZero));
    }
}
