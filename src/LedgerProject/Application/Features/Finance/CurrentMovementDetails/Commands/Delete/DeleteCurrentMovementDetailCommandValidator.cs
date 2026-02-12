using FluentValidation;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Delete;

public class DeleteCurrentMovementDetailCommandValidator : AbstractValidator<DeleteCurrentMovementDetailCommand>
{
    public DeleteCurrentMovementDetailCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}