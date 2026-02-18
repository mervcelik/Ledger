using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Identity.OperationClaims.Queries.GetList;

public class GetListOperationClaimQuery : BaseListQueryDto, IRequest<GetListResponse<GetListOperationClaimResponse>>
{
    public string? ContainsName { get; set; }
}

public class GetListOperationClaimQueryHandler : BaseHandlerManager<OperationClaim>, IRequestHandler<GetListOperationClaimQuery, GetListResponse<GetListOperationClaimResponse>>
{
    public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        : base(operationClaimRepository, mapper)
    {
    }

    public async Task<GetListResponse<GetListOperationClaimResponse>> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<OperationClaim, bool>>? predicate = x => x.Id > 0;
        if (!string.IsNullOrEmpty(request.ContainsName))
        {
            predicate = predicate.And(x => x.Name.Contains(request.ContainsName));
        }

        return await GetListAsync<GetListOperationClaimResponse>(request, cancellationToken: cancellationToken);
    }
}
