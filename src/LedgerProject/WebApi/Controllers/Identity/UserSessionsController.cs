using Application.Features.Identity.UserSessions.Commands.Create;
using Application.Features.Identity.UserSessions.Commands.Delete;
using Application.Features.Identity.UserSessions.Commands.Update;
using Application.Features.Identity.UserSessions.Queries.Get;
using Application.Features.Identity.UserSessions.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity;

public class UserSessionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserSessionCommand createUserSessionCommand)
    {
        CreatedUserSessionResponse? response = await Mediator.Send(createUserSessionCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserSessionCommand deleteUserSessionCommand)
    {
        DeletedUserSessionResponse? response = await Mediator.Send(deleteUserSessionCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserSessionCommand updateUserSessionCommand)
    {
        UpdatedUserSessionResponse? response = await Mediator.Send(updateUserSessionCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListUserSessionQuery getListUserSessionQuery)
    {
        GetListResponse<GetListUserSessionResponse>? response = await Mediator.Send(getListUserSessionQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetUserSessionQuery dto)
    {
        GetUserSessionResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
