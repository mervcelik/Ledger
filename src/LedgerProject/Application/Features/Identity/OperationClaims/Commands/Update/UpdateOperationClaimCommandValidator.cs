using Application.Features.Identity.OperationClaims.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(oc => oc.Name).NotEmpty().WithMessage(LH.Get(OperationClaimMessages.OperationClaimNameCannotBeEmpty));
    }
}
