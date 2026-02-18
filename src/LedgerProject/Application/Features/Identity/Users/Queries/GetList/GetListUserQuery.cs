using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.Users.Queries.GetList;

public class GetListUserQuery : BaseListQueryDto, IRequest<GetListResponse<GetListUserResponse>>
{
    public string? UserName { get; set; }
    public bool? Status { get; set; }
}

public class GetListUserQueryHandler : BaseHandlerManager<User>, IRequestHandler<GetListUserQuery, GetListResponse<GetListUserResponse>>
{
    public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper)
    {
    }

    public async Task<GetListResponse<GetListUserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
    {
        return await GetListAsync<GetListUserResponse>(request, cancellationToken: cancellationToken);
    }
}
