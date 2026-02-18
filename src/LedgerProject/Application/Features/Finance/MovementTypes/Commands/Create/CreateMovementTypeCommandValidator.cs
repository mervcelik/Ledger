using Application.Features.Finance.MovementTypes.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Finance.MovementTypes.Commands.Create;

public class CreateMovementTypeCommandValidator : AbstractValidator<CreateMovementTypeCommand>
{
    public CreateMovementTypeCommandValidator()
    {
        RuleFor(x => x.CompanyId).GreaterThan(0).WithMessage(LH.Get(MovementTypeMessages.MovementTypeCompanyMustExist));
        RuleFor(x => x.Name).NotEmpty().WithMessage(LH.Get(MovementTypeMessages.MovementTypeNameCannotBeEmpty)).MaximumLength(100);
    }
}
