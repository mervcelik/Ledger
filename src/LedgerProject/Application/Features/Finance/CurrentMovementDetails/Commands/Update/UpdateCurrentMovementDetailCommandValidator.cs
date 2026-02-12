using FluentValidation;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Update;

public class UpdateCurrentMovementDetailCommandValidator : AbstractValidator<UpdateCurrentMovementDetailCommand>
{
    public UpdateCurrentMovementDetailCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

    }
}