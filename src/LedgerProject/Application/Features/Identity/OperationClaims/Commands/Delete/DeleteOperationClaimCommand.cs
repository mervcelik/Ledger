using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommand : BaseCommandDto, IRequest<DeletedOperationClaimResponse>
{
}

public class DeleteOperationClaimCommandHandler : BaseHandlerManager<OperationClaim>, IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimResponse>
{
    public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        : base(operationClaimRepository, mapper)
    {
    }

    public async Task<DeletedOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedOperationClaimResponse>(request, false, cancellationToken);
    }
}
