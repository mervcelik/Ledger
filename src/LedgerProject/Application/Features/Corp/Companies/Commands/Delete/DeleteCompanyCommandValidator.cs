using Application.Features.Corp.Companies.Constans;
using Application.Services.Localization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Commands.Delete;

public class DeleteCompanyCommandValidator:AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x=>x.Id).GreaterThan(0).WithMessage(LH.Get(CompanyMessages.CompanyIdGreaterThanZero));
    }
}
