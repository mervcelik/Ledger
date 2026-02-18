using Application.Features.Identity.OperationClaims.Commands.Create;
using Application.Features.Identity.OperationClaims.Commands.Delete;
using Application.Features.Identity.OperationClaims.Commands.Update;
using Application.Features.Identity.OperationClaims.Queries.GetById;
using Application.Features.Identity.OperationClaims.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity;

public class OperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimResponse? response = await Mediator.Send(createOperationClaimCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        DeletedOperationClaimResponse? response = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimResponse? response = await Mediator.Send(updateOperationClaimCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListOperationClaimQuery getListOperationClaimQuery)
    {
        GetListResponse<GetListOperationClaimResponse>? response = await Mediator.Send(getListOperationClaimQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetOperationClaimQuery dto)
    {
        GetOperationClaimResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
