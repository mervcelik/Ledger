using Application.Features.Identity.Users.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.Users.Commands.Delete;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(u => u.Id).GreaterThan(0).WithMessage(LH.Get(UserMessages.UserIdGreaterThanZero));
    }
}
