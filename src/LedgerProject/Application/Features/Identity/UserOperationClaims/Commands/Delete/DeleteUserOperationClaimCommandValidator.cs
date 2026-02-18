using Application.Features.Identity.UserOperationClaims.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommandValidator : AbstractValidator<DeleteUserOperationClaimCommand>
{
    public DeleteUserOperationClaimCommandValidator()
    {
        RuleFor(uoc => uoc.Id).GreaterThan(0).WithMessage(LH.Get(UserOperationClaimMessages.UserOperationClaimIdGreaterThanZero));
    }
}
