using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Queries.GetList;

public class GetListCurrentMovementQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCurrentMovementResponse>>
{
    public int? CompanyId { get; set; }
    public int? AccountPeriodId { get; set; }
}

public class GetListCurrentMovementQueryHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<GetListCurrentMovementQuery, GetListResponse<GetListCurrentMovementResponse>>
{
    public GetListCurrentMovementQueryHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper) : base(currentMovementRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListCurrentMovementResponse>> Handle(GetListCurrentMovementQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<CurrentMovement, bool>>? predicate = x => x.Id > 0;
        if (request.CompanyId != null)
        {
            predicate = predicate.And(f => f.CompanyId == request.CompanyId);
        }
        if (request.AccountPeriodId != null)
        {
            predicate = predicate.And(f => f.AccountingPeriodId == request.AccountPeriodId);
        }
        return await GetListAsync<GetListCurrentMovementResponse>(request, predicate,cancellationToken: cancellationToken);
    }
}