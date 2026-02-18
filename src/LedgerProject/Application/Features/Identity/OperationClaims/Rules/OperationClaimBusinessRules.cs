using Application.Features.Identity.OperationClaims.Constans;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly ILocalizationService _localizationService;

    public OperationClaimBusinessRules(
        IOperationClaimRepository operationClaimRepository,
        ILocalizationService localizationService)
    {
        _operationClaimRepository = operationClaimRepository;
        _localizationService = localizationService;
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenCreated(string name)
    {
        var existingOperationClaim = await _operationClaimRepository.GetAsync(oc => oc.Name == name);
        if (existingOperationClaim != null)
        {
            throw new BusinessException(_localizationService.Get(OperationClaimMessages.OperationClaimNameCanNotBeDuplicated));
        }
    }

    public async Task OperationClaimNameCanNotBeDuplicatedWhenUpdated(int id, string name)
    {
        var existingOperationClaim = await _operationClaimRepository.GetAsync(oc => oc.Id != id && oc.Name == name);
        if (existingOperationClaim != null)
        {
            throw new BusinessException(_localizationService.Get(OperationClaimMessages.OperationClaimNameCanNotBeDuplicated));
        }
    }
}
