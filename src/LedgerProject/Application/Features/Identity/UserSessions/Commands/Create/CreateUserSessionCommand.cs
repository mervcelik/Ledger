using Application.Features.Identity.UserSessions.Rules;
using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.UserSessions.Commands.Create;

public class CreateUserSessionCommand : BaseCommandDto, IRequest<CreatedUserSessionResponse>
{
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? Description { get; set; }
}

public class CreateUserSessionCommandHandler : BaseHandlerManager<UserSession>, IRequestHandler<CreateUserSessionCommand, CreatedUserSessionResponse>
{
    private readonly UserSessionBusinessRules _userSessionBusinessRules;

    public CreateUserSessionCommandHandler(
        IMapper mapper,
        IUserSessionRepository userSessionRepository,
        UserSessionBusinessRules userSessionBusinessRules)
        : base(userSessionRepository, mapper)
    {
        _userSessionBusinessRules = userSessionBusinessRules;
    }

    public async Task<CreatedUserSessionResponse> Handle(CreateUserSessionCommand request, CancellationToken cancellationToken)
    {
        await _userSessionBusinessRules.UserMustExist(request.UserId);
        await _userSessionBusinessRules.UserSessionTokensMustNotBeEmpty(request.AccessToken, request.RefreshToken);
        _userSessionBusinessRules.ExpirationDateMustBeInFuture(request.ExpirationDate);

        return await CreateAsync<CreatedUserSessionResponse>(request, cancellationToken);
    }
}
