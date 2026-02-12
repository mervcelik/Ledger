using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Delete;

public class DeleteCurrentMovementDetailCommand : BaseCommandDto, IRequest<DeletedCurrentMovementDetailResponse>
{

}
public class DeleteCurrentMovementDetailCommandHandler : BaseHandlerManager<CurrentMovementDetail>, IRequestHandler<DeleteCurrentMovementDetailCommand, DeletedCurrentMovementDetailResponse>
{
    public DeleteCurrentMovementDetailCommandHandler(ICurrentMovementDetailRepository currentMovementDetailRepository, IMapper mapper) : base(currentMovementDetailRepository, mapper)
    {

    }
    public async Task<DeletedCurrentMovementDetailResponse> Handle(DeleteCurrentMovementDetailCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedCurrentMovementDetailResponse>(request,false,cancellationToken);
    }
}
