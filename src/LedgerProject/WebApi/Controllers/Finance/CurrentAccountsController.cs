using Application.Features.Finance.CurrentAccounts.Commands.Create;
using Application.Features.Finance.CurrentAccounts.Commands.Delete;
using Application.Features.Finance.CurrentAccounts.Commands.Update;
using Application.Features.Finance.CurrentAccounts.Queries.Get;
using Application.Features.Finance.CurrentAccounts.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Finance;

public class CurrentAccountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCurrentAccountCommand createCurrentAccountCommand)
    {
        CreatedCurrentAccountResponse? response = await Mediator.Send(createCurrentAccountCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCurrentAccountCommand deleteCurrentAccountCommand)
    {
        DeletedCurrentAccountResponse? response = await Mediator.Send(deleteCurrentAccountCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCurrentAccountCommand updateCurrentAccountCommand)
    {
        UpdatedCurrentAccountResponse? response = await Mediator.Send(updateCurrentAccountCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListCurrentAccountQuery getListCurrentAccountQuery)
    {
        GetListResponse<GetListCurrentAccountResponse>? response = await Mediator.Send(getListCurrentAccountQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetCurrentAccountQuery dto)
    {
        GetCurrentAccountResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
