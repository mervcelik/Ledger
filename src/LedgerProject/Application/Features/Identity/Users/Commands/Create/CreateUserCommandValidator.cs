using Application.Features.Identity.Users.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserFirstNameNotEmpty))
            .MinimumLength(2).WithMessage(LH.Get(UserMessages.UserFirstNameMinLength));

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserLastNameNotEmpty))
            .MinimumLength(2).WithMessage(LH.Get(UserMessages.UserLastNameMinLength));

        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserUserNameNotEmpty))
            .MinimumLength(3).WithMessage(LH.Get(UserMessages.UserUserNameMinLength));

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage(LH.Get(UserMessages.UserPasswordNotEmpty))
            .MinimumLength(8).WithMessage(LH.Get(UserMessages.UserPasswordMinLength));
    }
}
