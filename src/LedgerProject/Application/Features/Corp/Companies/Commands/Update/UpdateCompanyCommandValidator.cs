using Application.Features.Corp.Companies.Constans;
using Application.Services.Localization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Commands.Update;

public class UpdateCompanyCommandValidator:AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(LH.Get(CompanyMessages.CompanyNameNotEmpty));
        RuleFor(c => c.Name).MinimumLength(3).WithMessage(LH.Get(CompanyMessages.CompanyNameLenght));
    }
}
