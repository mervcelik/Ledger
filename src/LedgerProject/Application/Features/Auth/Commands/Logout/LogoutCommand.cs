using Application.Features.Auth.Constatnts;
using Application.Repositories.Identity;
using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Auth.Commands.Logout;

public class LogoutCommand : IRequest<LoggedOutResponse>
{
    public string RefreshToken { get; set; }
}

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LoggedOutResponse>
{
    private readonly IUserSessionRepository _userSessionRepository;

    public LogoutCommandHandler(IUserSessionRepository userSessionRepository)
    {
        _userSessionRepository = userSessionRepository;
    }

    public async Task<LoggedOutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var session = await _userSessionRepository.GetAsync(
            us => us.RefreshToken == request.RefreshToken,
            cancellationToken: cancellationToken);

        if (session == null)
        {
            throw new BusinessException(LH.Get(AuthMessages.SessionNotFound));
        }

        if (session.LogoutDate == null)
        {
            session.LogoutDate = DateTime.UtcNow;
            await _userSessionRepository.UpdateAsync(session);
        }

        return new LoggedOutResponse
        {
            UserId = session.UserId,
            LogoutDate = session.LogoutDate ?? DateTime.UtcNow
        };
    }
}
