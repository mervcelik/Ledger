using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.UserSessions.Commands.Delete;

public class DeleteUserSessionCommand : BaseCommandDto, IRequest<DeletedUserSessionResponse>
{
}

public class DeleteUserSessionCommandHandler : BaseHandlerManager<UserSession>, IRequestHandler<DeleteUserSessionCommand, DeletedUserSessionResponse>
{
    public DeleteUserSessionCommandHandler(IUserSessionRepository userSessionRepository, IMapper mapper)
        : base(userSessionRepository, mapper)
    {
    }

    public async Task<DeletedUserSessionResponse> Handle(DeleteUserSessionCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedUserSessionResponse>(request, false, cancellationToken);
    }
}
