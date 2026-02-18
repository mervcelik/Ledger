using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using Domain.Entities.Identity;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Identity.Users.Queries.Get;

public class GetUserQuery : BaseQueryDto, IRequest<GetUserResponse>
{
}

public class GetUserQueryHandler : BaseHandlerManager<User>, IRequestHandler<GetUserQuery, GetUserResponse>
{
    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper)
    {
    }

    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<User, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetUserResponse>(predicate, cancellationToken: cancellationToken);
    }
}
