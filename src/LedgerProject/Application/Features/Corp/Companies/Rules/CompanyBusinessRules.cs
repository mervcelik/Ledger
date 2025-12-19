using Application.Features.Corp.Companies.Constans;
using Application.Repositories.Corp;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Rules;

public class CompanyBusinessRules
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILocalizationService _localizationService;
    public CompanyBusinessRules(ICompanyRepository companyRepository, ILocalizationService localizationService)
    {
        _companyRepository = companyRepository;
        _localizationService = localizationService;
    }

    public async Task CompanyNameMustBeUniqueWhenCreating(string name)
    {
        var existingCompany = await _companyRepository.GetAsync(c => c.Name == name);
        if (existingCompany != null)
        {
            throw new BusinessException(_localizationService.Get(CompanyMessages.CompanyNotUnique));
        }
    }

    internal async Task CompanyNameMustBeUniqueWhenUpdating(int? id, string name)
    {
        var existingCompany = await _companyRepository.GetAsync(c => c.Name == name && c.Id!= id);
        if (existingCompany != null)
        {
            throw new BusinessException(_localizationService.Get(CompanyMessages.CompanyNotUnique));
        }
    }
}
