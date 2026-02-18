using Application.Features.Identity.OperationClaims.Rules;
using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.OperationClaims.Commands.Create;

public class CreateOperationClaimCommand : BaseCommandDto, IRequest<CreatedOperationClaimResponse>
{
    public string Name { get; set; }
}

public class CreateOperationClaimCommandHandler : BaseHandlerManager<OperationClaim>, IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimResponse>
{
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public CreateOperationClaimCommandHandler(
        IMapper mapper,
        IOperationClaimRepository operationClaimRepository,
        OperationClaimBusinessRules operationClaimBusinessRules)
        : base(operationClaimRepository, mapper)
    {
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<CreatedOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenCreated(request.Name);

        return await CreateAsync<CreatedOperationClaimResponse>(request, cancellationToken);
    }
}
