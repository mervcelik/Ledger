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

namespace Application.Features.Finance.CurrentMovements.Queries.GetList;

public class GetListCurrentMovementQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCurrentMovementQuery>>
{
    public int? CompanyId { get; set; }
    public int? AccountPeriodId { get; set; }
}

public class GetListCurrentMovementQueryHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<GetListCurrentMovementQuery, GetListResponse<GetListCurrentMovementQuery>>
{
    public GetListCurrentMovementQueryHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper) : base(currentMovementRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListCurrentMovementQuery>> Handle(GetListCurrentMovementQuery request, CancellationToken cancellationToken)
    {
        if (request.CompanyId != null)
        {
            predicate = predicate.And(f => f.CompanyId == request.CompanyId);
        }
        if (request.AccountPeriodId != null)
        {
            predicate = predicate.And(f => f.AccountingPeriodId == request.AccountPeriodId);
        }
        return await GetListAsync<GetListCurrentMovementQuery>(request, cancellationToken: cancellationToken);
    }
}