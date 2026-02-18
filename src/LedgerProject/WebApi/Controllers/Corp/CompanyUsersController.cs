using Application.Features.Corp.CompanyUsers.Commands.Create;
using Application.Features.Corp.CompanyUsers.Commands.Delete;
using Application.Features.Corp.CompanyUsers.Commands.Update;
using Application.Features.Corp.CompanyUsers.Queries.GetById;
using Application.Features.Corp.CompanyUsers.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Corp;

public class CompanyUsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCompanyUserCommand createCompanyUserCommand)
    {
        CreatedCompanyUserResponse? response = await Mediator.Send(createCompanyUserCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCompanyUserCommand deleteCompanyUserCommand)
    {
        DeletedCompanyUserResponse? response = await Mediator.Send(deleteCompanyUserCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCompanyUserCommand updateCompanyUserCommand)
    {
        UpdatedCompanyUserResponse? response = await Mediator.Send(updateCompanyUserCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListCompanyUserQuery getListCompanyUserQuery)
    {
        GetListResponse<GetListCompanyUserResponse>? response = await Mediator.Send(getListCompanyUserQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetCompanyUserQuery dto)
    {
        GetCompanyUserResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
