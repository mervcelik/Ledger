using Application.Features.Identity.UserSessions.Constans;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Identity.UserSessions.Rules;

public class UserSessionBusinessRules
{
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILocalizationService _localizationService;

    public UserSessionBusinessRules(
        IUserSessionRepository userSessionRepository,
        IUserRepository userRepository,
        ILocalizationService localizationService)
    {
        _userSessionRepository = userSessionRepository;
        _userRepository = userRepository;
        _localizationService = localizationService;
    }

    public async Task UserMustExist(int userId)
    {
        var user = await _userRepository.GetAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new BusinessException(_localizationService.Get(UserSessionMessages.UserSessionUserMustExist));
        }
    }

    public async Task UserSessionTokensMustNotBeEmpty(string accessToken, string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(accessToken))
        {
            throw new BusinessException(_localizationService.Get(UserSessionMessages.UserSessionAccessTokenCannotBeEmpty));
        }
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            throw new BusinessException(_localizationService.Get(UserSessionMessages.UserSessionRefreshTokenCannotBeEmpty));
        }
    }

    public void ExpirationDateMustBeInFuture(DateTime expirationDate)
    {
        if (expirationDate <= DateTime.UtcNow)
        {
            throw new BusinessException(_localizationService.Get(UserSessionMessages.UserSessionExpirationDateCannotBeEmpty));
        }
    }
}
