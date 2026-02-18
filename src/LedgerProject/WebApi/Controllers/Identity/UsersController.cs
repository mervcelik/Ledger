using Application.Features.Identity.Users.Commands.Create;
using Application.Features.Identity.Users.Commands.Delete;
using Application.Features.Identity.Users.Commands.Update;
using Application.Features.Identity.Users.Queries.Get;
using Application.Features.Identity.Users.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity;

public class UsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserResponse? response = await Mediator.Send(createUserCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        DeletedUserResponse? response = await Mediator.Send(deleteUserCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserResponse? response = await Mediator.Send(updateUserCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListUserQuery getListUserQuery)
    {
        GetListResponse<GetListUserResponse>? response = await Mediator.Send(getListUserQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetUserQuery dto)
    {
        GetUserResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
