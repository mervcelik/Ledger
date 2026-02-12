using Application.Features.Finance.CurrentMovements.Commands.Create;
using Application.Features.Finance.CurrentMovements.Commands.Delete;
using Application.Features.Finance.CurrentMovements.Commands.Update;
using Application.Features.Finance.CurrentMovements.Queries.Get;
using Application.Features.Finance.CurrentMovements.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Finance;

public class CurrentMovementsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCurrentMovementCommand createCurrentMovementCommand)
    {
        CreatedCurrentMovementResponse? response = await Mediator.Send(createCurrentMovementCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCurrentMovementCommand deleteCurrentMovementCommand)
    {
        DeletedCurrentMovementResponse? response = await Mediator.Send(deleteCurrentMovementCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCurrentMovementCommand updateCurrentMovementCommand)
    {
        UpdatedCurrentMovementResponse? response = await Mediator.Send(updateCurrentMovementCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListCurrentMovementQuery getListCurrentMovementQuery)
    {
        GetListResponse<GetListCurrentMovementResponse>? response = await Mediator.Send(getListCurrentMovementQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetCurrentMovementQuery dto)
    {
        GetCurrentMovementResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}