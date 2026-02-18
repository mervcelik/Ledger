using Application.Features.Identity.Users.Constans;
using Application.Repositories.Identity;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.Security.Hashing;
using Domain.Entities.Identity;
using MediatR;

namespace Application.Features.Identity.Users.Commands.Create;

public class CreateUserCommand : BaseCommandDto, IRequest<CreatedUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; } = true;
}

public class CreateUserCommandHandler : BaseHandlerManager<User>, IRequestHandler<CreateUserCommand, CreatedUserResponse>
{
    private readonly IHashingService _hashingService;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IHashingService hashingService)
        : base(userRepository, mapper)
    {
        _hashingService = hashingService;
    }

    public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _hashingService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        
        User user = _mapper.Map<User>(request);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _repository.AddAsync(user);
        return _mapper.Map<CreatedUserResponse>(user);
    }
}
