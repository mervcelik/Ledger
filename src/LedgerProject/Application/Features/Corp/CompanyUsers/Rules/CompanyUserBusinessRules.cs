using Application.Features.Corp.CompanyUsers.Constans;
using Application.Repositories.Corp;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.CompanyUsers.Rules;

public class CompanyUserBusinessRules
{
    private readonly ICompanyUserRepository _companyUserRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyUserBusinessRules(
        ICompanyUserRepository companyUserRepository, 
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        ILocalizationService localizationService)
    {
        _companyUserRepository = companyUserRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _localizationService = localizationService;
    }

    public async Task CompanyUserMustBeUniqueWhenCreating(int userId, int companyId)
    {
        var existingCompanyUser = await _companyUserRepository.GetAsync(cu => cu.UserId == userId && cu.CompanyId == companyId);
        if (existingCompanyUser != null)
        {
            throw new BusinessException(_localizationService.Get(CompanyUserMessages.CompanyUserNotUnique));
        }
    }

    public async Task CompanyMustExist(int companyId)
    {
        var company = await _companyRepository.GetAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new BusinessException(_localizationService.Get(CompanyUserMessages.CompanyUserCompanyMustExist));
        }
    }

    public async Task UserMustExist(int userId)
    {
        var user = await _userRepository.GetAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new BusinessException(_localizationService.Get(CompanyUserMessages.CompanyUserUserMustExist));
        }
    }
}
