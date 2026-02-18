using Application.Features.Identity.UserSessions.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.UserSessions.Commands.Create;

public class CreateUserSessionCommandValidator : AbstractValidator<CreateUserSessionCommand>
{
    public CreateUserSessionCommandValidator()
    {
        RuleFor(us => us.UserId).GreaterThan(0).WithMessage(LH.Get(UserSessionMessages.UserSessionUserIdNotEmpty));
        RuleFor(us => us.AccessToken).NotEmpty().WithMessage(LH.Get(UserSessionMessages.UserSessionAccessTokenCannotBeEmpty));
        RuleFor(us => us.RefreshToken).NotEmpty().WithMessage(LH.Get(UserSessionMessages.UserSessionRefreshTokenCannotBeEmpty));
    }
}
