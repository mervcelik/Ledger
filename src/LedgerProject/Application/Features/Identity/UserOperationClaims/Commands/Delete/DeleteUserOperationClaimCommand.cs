using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommand : BaseCommandDto, IRequest<DeletedUserOperationClaimResponse>
{
}

public class DeleteUserOperationClaimCommandHandler : BaseHandlerManager<UserOperationClaim>, IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimResponse>
{
    public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        : base(userOperationClaimRepository, mapper)
    {
    }

    public async Task<DeletedUserOperationClaimResponse> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedUserOperationClaimResponse>(request, false, cancellationToken);
    }
}
