using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.UserSessions.Commands.Update;

public class UpdateUserSessionCommand : BaseCommandDto, IRequest<UpdatedUserSessionResponse>
{
    public DateTime? LogoutDate { get; set; }
}

public class UpdateUserSessionCommandHandler : BaseHandlerManager<UserSession>, IRequestHandler<UpdateUserSessionCommand, UpdatedUserSessionResponse>
{
    public UpdateUserSessionCommandHandler(IUserSessionRepository userSessionRepository, IMapper mapper)
        : base(userSessionRepository, mapper)
    {
    }

    public async Task<UpdatedUserSessionResponse> Handle(UpdateUserSessionCommand request, CancellationToken cancellationToken)
    {
        return await UpdateAsync<UpdatedUserSessionResponse>(request, cancellationToken);
    }
}
