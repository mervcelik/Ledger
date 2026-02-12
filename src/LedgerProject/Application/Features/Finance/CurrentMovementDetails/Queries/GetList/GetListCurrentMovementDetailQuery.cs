using Application.Features.Finance.CurrentMovementDetails.Queries.Get;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Queries.GetList;

public class GetListCurrentMovementDetailQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCurrentMovementDetailResponse>>
{
    public int? CurrentMovementId { get; set; }
}

public class GetListCurrentMovementDetailQueryHandler : BaseHandlerManager<CurrentMovementDetail>, IRequestHandler<GetListCurrentMovementDetailQuery, GetListResponse<GetListCurrentMovementDetailResponse>>
{
    public GetListCurrentMovementDetailQueryHandler(ICurrentMovementDetailRepository currentMovementDetailRepository, IMapper mapper) : base(currentMovementDetailRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListCurrentMovementDetailResponse>> Handle(GetListCurrentMovementDetailQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<CurrentMovementDetail, bool>>? predicate = x => x.Id > 0;
        if (request.CurrentMovementId != null)
        {
            predicate = predicate.And(f => f.CurrentMovementId == request.CurrentMovementId);
        }

        return await GetListAsync<GetListCurrentMovementDetailResponse>(request, predicate, null, null, cancellationToken: cancellationToken);
    }
}