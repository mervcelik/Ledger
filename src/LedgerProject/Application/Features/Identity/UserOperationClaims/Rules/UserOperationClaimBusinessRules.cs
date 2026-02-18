using Application.Features.Identity.UserOperationClaims.Constans;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly ILocalizationService _localizationService;

    public UserOperationClaimBusinessRules(
        IUserOperationClaimRepository userOperationClaimRepository,
        IUserRepository userRepository,
        IOperationClaimRepository operationClaimRepository,
        ILocalizationService localizationService)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userRepository = userRepository;
        _operationClaimRepository = operationClaimRepository;
        _localizationService = localizationService;
    }

    public async Task UserOperationClaimMustBeUniqueWhenCreating(int userId, int operationClaimId)
    {
        var existingUserOperationClaim = await _userOperationClaimRepository.GetAsync(
            uoc => uoc.UserId == userId && uoc.OperationClaimId == operationClaimId);
        if (existingUserOperationClaim != null)
        {
            throw new BusinessException(_localizationService.Get(UserOperationClaimMessages.UserOperationClaimNotUnique));
        }
    }

    public async Task UserMustExist(int userId)
    {
        var user = await _userRepository.GetAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new BusinessException(_localizationService.Get(UserOperationClaimMessages.UserOperationClaimUserMustExist));
        }
    }

    public async Task OperationClaimMustExist(int operationClaimId)
    {
        var operationClaim = await _operationClaimRepository.GetAsync(oc => oc.Id == operationClaimId);
        if (operationClaim == null)
        {
            throw new BusinessException(_localizationService.Get(UserOperationClaimMessages.UserOperationClaimOperationClaimMustExist));
        }
    }
}
