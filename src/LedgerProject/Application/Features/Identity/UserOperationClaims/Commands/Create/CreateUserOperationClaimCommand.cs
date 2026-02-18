using Application.Features.Identity.UserOperationClaims.Rules;
using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : BaseCommandDto, IRequest<CreatedUserOperationClaimResponse>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}

public class CreateUserOperationClaimCommandHandler : BaseHandlerManager<UserOperationClaim>, IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimResponse>
{
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public CreateUserOperationClaimCommandHandler(
        IMapper mapper,
        IUserOperationClaimRepository userOperationClaimRepository,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        : base(userOperationClaimRepository, mapper)
    {
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<CreatedUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.UserMustExist(request.UserId);
        await _userOperationClaimBusinessRules.OperationClaimMustExist(request.OperationClaimId);
        await _userOperationClaimBusinessRules.UserOperationClaimMustBeUniqueWhenCreating(request.UserId, request.OperationClaimId);

        return await CreateAsync<CreatedUserOperationClaimResponse>(request, cancellationToken);
    }
}
