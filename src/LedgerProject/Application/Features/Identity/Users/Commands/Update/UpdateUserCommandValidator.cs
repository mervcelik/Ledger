using Application.Features.Identity.Users.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Id).GreaterThan(0).WithMessage(LH.Get(UserMessages.UserIdGreaterThanZero));

        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserFirstNameNotEmpty))
            .MinimumLength(2).WithMessage(LH.Get(UserMessages.UserFirstNameMinLength));

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserLastNameNotEmpty))
            .MinimumLength(2).WithMessage(LH.Get(UserMessages.UserLastNameMinLength));

        RuleFor(u => u.Password)
            .MinimumLength(8).WithMessage(LH.Get(UserMessages.UserPasswordMinLength))
            .When(u => !string.IsNullOrEmpty(u.Password));
    }
}
