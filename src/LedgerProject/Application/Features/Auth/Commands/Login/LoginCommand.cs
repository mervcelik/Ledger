using Application.Features.Auth.Constatnts;
using Application.Features.Identity.UserSessions.Rules;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly UserSessionBusinessRules _userSessionBusinessRules;
    private readonly IHashingService _hashingService;
    private readonly ITokenHelper _tokenHelper;
    public LoginCommandHandler(
        IUserRepository userRepository,
        IUserOperationClaimRepository userOperationClaimRepository,
        IUserSessionRepository userSessionRepository,
        UserSessionBusinessRules userSessionBusinessRules,
        IHashingService hashingService,
ITokenHelper tokenHelper)
    {
        _userRepository = userRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
        _userSessionRepository = userSessionRepository;
        _userSessionBusinessRules = userSessionBusinessRules;
        _hashingService = hashingService;
        _tokenHelper = tokenHelper;
    }

    public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(
            u => u.UserName == request.EmailOrUsername,
            cancellationToken: cancellationToken);

        if (user == null || !_hashingService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new BusinessException(LH.Get(AuthMessages.InvalidUserName));
        }

        var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
            uoc => uoc.UserId == user.Id,
            include: q => q.Include(x => x.OperationClaim),
            cancellationToken: cancellationToken);

        var sessionDto = _tokenHelper.CreateToken(new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
        }, userOperationClaims.Items.Select(uoc => uoc.OperationClaim.Name).ToList());

        var userSession = new UserSession
        {
            AccessToken = sessionDto.AccessToken,
            RefreshToken = sessionDto.RefreshToken,
            UserId = user.Id,
            ExpirationDate = sessionDto.Expiration
        };
        await _userSessionRepository.AddAsync(userSession);

        return new LoggedResponse
        {
            UserId = user.Id,
            UserName = user.UserName,
            AccessToken = userSession.AccessToken,
            AccessTokenExpiration = userSession.ExpirationDate,
            RefreshToken = userSession.RefreshToken,
        };
    }
}
