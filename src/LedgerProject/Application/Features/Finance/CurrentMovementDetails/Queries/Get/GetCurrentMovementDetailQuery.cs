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

namespace Application.Features.Finance.CurrentMovementDetails.Queries.Get;

public class GetCurrentMovementDetailQuery : BaseQueryDto, IRequest<GetCurrentMovementDetailResponse>
{
}

public class GetCurrentMovementDetailQueryHandler : BaseHandlerManager<CurrentMovementDetail>, IRequestHandler<GetCurrentMovementDetailQuery, GetCurrentMovementDetailResponse>
{
    public GetCurrentMovementDetailQueryHandler(ICurrentMovementDetailRepository currentMovementDetailRepository, IMapper mapper) : base(currentMovementDetailRepository, mapper)
    {
    }
    public async Task<GetCurrentMovementDetailResponse> Handle(GetCurrentMovementDetailQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<CurrentMovementDetail, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetCurrentMovementDetailResponse>(predicate, cancellationToken: cancellationToken);
    }
}

