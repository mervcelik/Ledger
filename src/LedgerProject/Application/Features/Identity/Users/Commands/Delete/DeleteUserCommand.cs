using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.Users.Commands.Delete;

public class DeleteUserCommand : BaseCommandDto, IRequest<DeletedUserResponse>
{
}

public class DeleteUserCommandHandler : BaseHandlerManager<User>, IRequestHandler<DeleteUserCommand, DeletedUserResponse>
{
    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        : base(userRepository, mapper)
    {
    }

    public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedUserResponse>(request, false, cancellationToken);
    }
}
