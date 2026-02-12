using FluentValidation;

namespace Application.Features.Finance.MovementTypes.Commands.Create;

public class CreateMovementTypeCommandValidator : AbstractValidator<CreateMovementTypeCommand>
{
    public CreateMovementTypeCommandValidator()
    {
        RuleFor(x => x.CompanyId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}