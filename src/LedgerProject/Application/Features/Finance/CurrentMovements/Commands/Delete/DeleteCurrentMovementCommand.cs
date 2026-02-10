using Application.Features.Finance.CurrentAccounts.Commands.Delete;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Commands.Delete;

public class DeleteCurrentMovementCommand : BaseCommandDto, IRequest<DeletedCurrentMovementResponse>
{
}
public class DeleteCurrentMovementCommandHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<DeleteCurrentMovementCommand, DeletedCurrentMovementResponse>
{
    public DeleteCurrentMovementCommandHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper) : base(currentMovementRepository, mapper)
    {

    }
    public async Task<DeletedCurrentMovementResponse> Handle(DeleteCurrentMovementCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedCurrentMovementResponse>(request, false, cancellationToken);
    }
}