using Application.Features.Identity.UserOperationClaims.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(uoc => uoc.UserId).GreaterThan(0).WithMessage(LH.Get(UserOperationClaimMessages.UserOperationClaimUserIdNotEmpty));
        RuleFor(uoc => uoc.OperationClaimId).GreaterThan(0).WithMessage(LH.Get(UserOperationClaimMessages.UserOperationClaimOperationClaimIdNotEmpty));
    }
}
