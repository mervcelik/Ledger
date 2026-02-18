using Application.Features.Identity.OperationClaims.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(oc => oc.Id).GreaterThan(0).WithMessage(LH.Get(OperationClaimMessages.OperationClaimIdGreaterThanZero));
    }
}
