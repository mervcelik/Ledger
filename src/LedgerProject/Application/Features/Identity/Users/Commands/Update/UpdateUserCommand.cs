using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.Security.Hashing;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.Users.Commands.Update;

public class UpdateUserCommand : BaseCommandDto, IRequest<UpdatedUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Password { get; set; }
    public bool Status { get; set; }
}

public class UpdateUserCommandHandler : BaseHandlerManager<User>, IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
{
    private readonly IHashingService _hashingService;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IHashingService hashingService)
        : base(userRepository, mapper)
    {
        _hashingService = hashingService;
    }

    public async Task<UpdatedUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        user = _mapper.Map(request, user);

        if (!string.IsNullOrEmpty(request.Password))
        {
            _hashingService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        await _repository.UpdateAsync(user);
        return _mapper.Map<UpdatedUserResponse>(user);
    }
}
