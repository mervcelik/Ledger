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

namespace Application.Features.Finance.MovementTypes.Queries.GetList;

public class GetListMovementTypeQuery : BaseListQueryDto, IRequest<GetListResponse<GetListMovementTypeResponse>>
{
    public int? CompanyId { get; set; }
}

public class GetListMovementTypeQueryHandler : BaseHandlerManager<MovementType>, IRequestHandler<GetListMovementTypeQuery, GetListResponse<GetListMovementTypeResponse>>
{
    public GetListMovementTypeQueryHandler(IMovementTypeRepository MovementTypeRepository, IMapper mapper) : base(MovementTypeRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListMovementTypeResponse>> Handle(GetListMovementTypeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<MovementType, bool>>? predicate = x => x.Id > 0;
        if (request.CompanyId != null)
        {
            predicate = predicate.And(f => f.CompanyId == request.CompanyId);
        }

        return await GetListAsync<GetListMovementTypeResponse>(request, predicate, null, null, cancellationToken: cancellationToken);
    }
}