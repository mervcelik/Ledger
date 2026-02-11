using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Queries.Get;

public class GetCurrentMovementQuery : BaseQueryDto, IRequest<GetCurrentMovementResponse>
{
}
public class GetCurrentMovementQueryHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<GetCurrentMovementQuery, GetCurrentMovementResponse>
{
    public GetCurrentMovementQueryHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper) : base(currentMovementRepository, mapper)
    {
    }
    public async Task<GetCurrentMovementResponse> Handle(GetCurrentMovementQuery request, CancellationToken cancellationToken)
    {
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetCurrentMovementResponse>(cancellationToken: cancellationToken);
    }
}