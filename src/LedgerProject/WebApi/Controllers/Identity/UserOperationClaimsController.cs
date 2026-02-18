using Application.Features.Identity.UserOperationClaims.Commands.Create;
using Application.Features.Identity.UserOperationClaims.Commands.Delete;
using Application.Features.Identity.UserOperationClaims.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity;

public class UserOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimResponse? response = await Mediator.Send(createUserOperationClaimCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        DeletedUserOperationClaimResponse? response = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListUserOperationClaimQuery getListUserOperationClaimQuery)
    {
        GetListResponse<GetListUserOperationClaimResponse>? response = await Mediator.Send(getListUserOperationClaimQuery);
        return Ok(response);
    }
}
