using Core.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand:IRequest<LoggedResponse>
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
}
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
{
    public Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
