using Application.Features.Finance.MovementTypes.Commands.Create;
using Application.Features.Finance.MovementTypes.Commands.Delete;
using Application.Features.Finance.MovementTypes.Commands.Update;
using Application.Features.Finance.MovementTypes.Queries.Get;
using Application.Features.Finance.MovementTypes.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Finance;

public class MovementTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMovementTypeCommand createMovementTypeCommand)
    {
        CreatedMovementTypeResponse? response = await Mediator.Send(createMovementTypeCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteMovementTypeCommand deleteMovementTypeCommand)
    {
        DeletedMovementTypeResponse? response = await Mediator.Send(deleteMovementTypeCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMovementTypeCommand updateMovementTypeCommand)
    {
        UpdatedMovementTypeResponse? response = await Mediator.Send(updateMovementTypeCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListMovementTypeQuery getListMovementTypeQuery)
    {
        GetListResponse<GetListMovementTypeResponse>? response = await Mediator.Send(getListMovementTypeQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetMovementTypeQuery dto)
    {
        GetMovementTypeResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
