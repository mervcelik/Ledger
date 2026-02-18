using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Identity.UserSessions.Queries.GetList;

public class GetListUserSessionQuery : BaseListQueryDto, IRequest<GetListResponse<GetListUserSessionResponse>>
{
    public int? UserId { get; set; }
}

public class GetListUserSessionQueryHandler : BaseHandlerManager<UserSession>, IRequestHandler<GetListUserSessionQuery, GetListResponse<GetListUserSessionResponse>>
{
    public GetListUserSessionQueryHandler(IUserSessionRepository userSessionRepository, IMapper mapper)
        : base(userSessionRepository, mapper)
    {
    }

    public async Task<GetListResponse<GetListUserSessionResponse>> Handle(GetListUserSessionQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<UserSession, bool>>? predicate = x => x.Id > 0;
        if (request.UserId.HasValue)
        {
            predicate = predicate.And(x => x.UserId == request.UserId);
        }

        return await GetListAsync<GetListUserSessionResponse>(request, cancellationToken: cancellationToken);
    }
}
