using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Identity.UserOperationClaims.Queries.GetList;

public class GetListUserOperationClaimQuery : BaseListQueryDto, IRequest<GetListResponse<GetListUserOperationClaimResponse>>
{
    public int? UserId { get; set; }
    public int? OperationClaimId { get; set; }
}

public class GetListUserOperationClaimQueryHandler : BaseHandlerManager<UserOperationClaim>, IRequestHandler<GetListUserOperationClaimQuery, GetListResponse<GetListUserOperationClaimResponse>>
{
    public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        : base(userOperationClaimRepository, mapper)
    {
    }

    public async Task<GetListResponse<GetListUserOperationClaimResponse>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<UserOperationClaim, bool>>? predicate = x => x.Id > 0;
        if (request.UserId.HasValue)
        {
            predicate = predicate.And(x => x.UserId == request.UserId);
        }
        if (request.OperationClaimId.HasValue)
        {
            predicate = predicate.And(x => x.OperationClaimId == request.OperationClaimId);
        }

        return await GetListAsync<GetListUserOperationClaimResponse>(request, cancellationToken: cancellationToken);
    }
}
