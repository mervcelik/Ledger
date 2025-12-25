using Application.Features.Corp.Companies.Queries.GetById;
using Application.Features.Finance.AccountingPeriods.Commands.Create;
using Application.Features.Finance.AccountingPeriods.Commands.Delete;
using Application.Features.Finance.AccountingPeriods.Commands.Update;
using Application.Features.Finance.AccountingPeriods.Queries.Get;
using Application.Features.Finance.AccountingPeriods.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Finance;

public class AccountingPeriodsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountingPeriodCommand createAccountingPeriodCommand)
    {
        CreatedAccountingPeriodResponse? response = await Mediator.Send(createAccountingPeriodCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteAccountingPeriodCommand deleteAccountingPeriodCommand)
    {
        DeletedAccountingPeriodResponse? response = await Mediator.Send(deleteAccountingPeriodCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountingPeriodCommand updateAccountingPeriodCommand)
    {
        UpdatedAccountingPeriodResponse? response = await Mediator.Send(updateAccountingPeriodCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListAccountingPeriodQuery getListAccountingPeriodQuery)
    {
        GetListResponse<GetListAccountingPeriodResponse>? response = await Mediator.Send(getListAccountingPeriodQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetAccountingPeriodQuery dto)
    {
        GetAccountingPeriodResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
