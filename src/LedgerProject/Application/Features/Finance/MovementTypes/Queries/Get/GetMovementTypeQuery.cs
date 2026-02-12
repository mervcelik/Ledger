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

namespace Application.Features.Finance.MovementTypes.Queries.Get;

public class GetMovementTypeQuery : BaseQueryDto, IRequest<GetMovementTypeResponse>
{
}

public class GetMovementTypeQueryHandler : BaseHandlerManager<MovementType>, IRequestHandler<GetMovementTypeQuery, GetMovementTypeResponse>
{
    public GetMovementTypeQueryHandler(IMovementTypeRepository MovementTypeRepository, IMapper mapper) : base(MovementTypeRepository, mapper)
    {
    }
    public async Task<GetMovementTypeResponse> Handle(GetMovementTypeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<MovementType, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetMovementTypeResponse>(predicate, cancellationToken: cancellationToken);
    }
}


