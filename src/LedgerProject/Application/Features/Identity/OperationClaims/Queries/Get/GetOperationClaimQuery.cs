using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Identity.OperationClaims.Queries.GetById;

public class GetOperationClaimQuery : BaseQueryDto, IRequest<GetOperationClaimResponse>
{
}

public class GetOperationClaimQueryHandler : BaseHandlerManager<OperationClaim>, IRequestHandler<GetOperationClaimQuery, GetOperationClaimResponse>
{
    public GetOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        : base(operationClaimRepository, mapper)
    {
    }

    public async Task<GetOperationClaimResponse> Handle(GetOperationClaimQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<OperationClaim, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetOperationClaimResponse>(predicate, cancellationToken: cancellationToken);
    }
}
