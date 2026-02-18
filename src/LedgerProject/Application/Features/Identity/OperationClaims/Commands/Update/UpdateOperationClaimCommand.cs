using Application.Features.Identity.OperationClaims.Rules;
using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommand : BaseCommandDto, IRequest<UpdatedOperationClaimResponse>
{
    public string Name { get; set; }
}

public class UpdateOperationClaimCommandHandler : BaseHandlerManager<OperationClaim>, IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimResponse>
{
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public UpdateOperationClaimCommandHandler(
        IMapper mapper,
        IOperationClaimRepository operationClaimRepository,
        OperationClaimBusinessRules operationClaimBusinessRules)
        : base(operationClaimRepository, mapper)
    {
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<UpdatedOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenUpdated(Convert.ToInt32(request.Id), request.Name);

        return await UpdateAsync<UpdatedOperationClaimResponse>(request, cancellationToken);
    }
}
