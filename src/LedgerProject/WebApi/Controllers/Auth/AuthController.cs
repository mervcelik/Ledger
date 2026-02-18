using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Auth;

public class AuthController : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
}
