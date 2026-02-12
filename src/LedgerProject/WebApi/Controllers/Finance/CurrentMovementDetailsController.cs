using Application.Features.Finance.CurrentMovementDetails.Commands.Create;
using Application.Features.Finance.CurrentMovementDetails.Commands.Delete;
using Application.Features.Finance.CurrentMovementDetails.Commands.Update;
using Application.Features.Finance.CurrentMovementDetails.Queries.Get;
using Application.Features.Finance.CurrentMovementDetails.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Finance;

public class CurrentMovementDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCurrentMovementDetailCommand createCurrentMovementDetailCommand)
    {
        CreatedCurrentMovementDetailResponse? response = await Mediator.Send(createCurrentMovementDetailCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCurrentMovementDetailCommand deleteCurrentMovementDetailCommand)
    {
        DeletedCurrentMovementDetailResponse? response = await Mediator.Send(deleteCurrentMovementDetailCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCurrentMovementDetailCommand updateCurrentMovementDetailCommand)
    {
        UpdatedCurrentMovementDetailResponse? response = await Mediator.Send(updateCurrentMovementDetailCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListCurrentMovementDetailQuery getListCurrentMovementDetailQuery)
    {
        GetListResponse<GetListCurrentMovementDetailResponse>? response = await Mediator.Send(getListCurrentMovementDetailQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetCurrentMovementDetailQuery dto)
    {
        GetCurrentMovementDetailResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
