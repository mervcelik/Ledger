using Application.Features.Finance.CurrentMovementDetails.Constans;
using Application.Repositories.Finance;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Rules;

public class CurrentMovementDetailRules
{
    private readonly ICurrentMovementDetailRepository _currentMovementDetailRepository;
    private readonly ICurrentMovementRepository _currentMovementRepository;
    private readonly ILocalizationService _localizationService;

    public CurrentMovementDetailRules(
        ICurrentMovementDetailRepository currentMovementDetailRepository,
        ICurrentMovementRepository currentMovementRepository,
        ILocalizationService localizationService)
    {
        _currentMovementDetailRepository = currentMovementDetailRepository;
        _currentMovementRepository = currentMovementRepository;
        _localizationService = localizationService;
    }

    public async Task CurrentMovementMustExist(int currentMovementId)
    {
        var movement = await _currentMovementRepository.GetAsync(cm => cm.Id == currentMovementId);
        if (movement == null)
        {
            throw new BusinessException(_localizationService.Get(CurrentMovementDetailMessages.CurrentMovementMustExist));
        }
    }
}

