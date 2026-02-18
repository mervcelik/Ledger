using Application.Features.Identity.OperationClaims.Constans;
using Application.Services.Localization;
using FluentValidation;

namespace Application.Features.Identity.OperationClaims.Commands.Create;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(oc => oc.Name).NotEmpty().WithMessage(LH.Get(OperationClaimMessages.OperationClaimNameCannotBeEmpty));
    }
}
