using Application.Features.Finance.MovementTypes.Constans;
using Application.Repositories.Corp;
using Application.Repositories.Finance;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.MovementTypes.Rules;

public class MovementTypeBusinessRules
{
    private readonly IMovementTypeRepository _movementTypeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ILocalizationService _localizationService;

    public MovementTypeBusinessRules(
        IMovementTypeRepository movementTypeRepository,
        ICompanyRepository companyRepository,
        ILocalizationService localizationService)
    {
        _movementTypeRepository = movementTypeRepository;
        _companyRepository = companyRepository;
        _localizationService = localizationService;
    }

    public async Task MovementTypeNameCanNotBeDuplicatedWhenCreated(string name, int companyId)
    {
        var existingMovementType = await _movementTypeRepository.GetAsync(mt => mt.Name == name && mt.CompanyId == companyId);
        if (existingMovementType != null)
        {
            throw new BusinessException(_localizationService.Get(MovementTypeMessages.MovementTypeNameCanNotBeDuplicated));
        }
    }

    public async Task MovementTypeNameCanNotBeDuplicatedWhenUpdated(int id, string name, int companyId)
    {
        var existingMovementType = await _movementTypeRepository.GetAsync(mt => mt.Id != id && mt.Name == name && mt.CompanyId == companyId);
        if (existingMovementType != null)
        {
            throw new BusinessException(_localizationService.Get(MovementTypeMessages.MovementTypeNameCanNotBeDuplicated));
        }
    }

    public async Task CompanyMustExist(int companyId)
    {
        var company = await _companyRepository.GetAsync(c => c.Id == companyId);
        if (company == null)
        {
            throw new BusinessException(_localizationService.Get(MovementTypeMessages.MovementTypeCompanyMustExist));
        }
    }
}

