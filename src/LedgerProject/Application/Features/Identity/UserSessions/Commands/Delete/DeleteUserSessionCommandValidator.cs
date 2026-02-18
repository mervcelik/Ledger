using Application.Features.Identity.UserSessions.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.UserSessions.Commands.Delete;

public class DeleteUserSessionCommandValidator : AbstractValidator<DeleteUserSessionCommand>
{
    public DeleteUserSessionCommandValidator()
    {
        RuleFor(us => us.Id).GreaterThan(0).WithMessage(LH.Get(UserSessionMessages.UserSessionIdGreaterThanZero));
    }
}
