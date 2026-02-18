using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Identity;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Identity.UserSessions.Queries.Get;

public class GetUserSessionQuery : BaseQueryDto, IRequest<GetUserSessionResponse>
{
}

public class GetUserSessionQueryHandler : BaseHandlerManager<UserSession>, IRequestHandler<GetUserSessionQuery, GetUserSessionResponse>
{
    public GetUserSessionQueryHandler(IUserSessionRepository userSessionRepository, IMapper mapper)
        : base(userSessionRepository, mapper)
    {
    }

    public async Task<GetUserSessionResponse> Handle(GetUserSessionQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<UserSession, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetUserSessionResponse>(predicate, cancellationToken: cancellationToken);
    }
}
