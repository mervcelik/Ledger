using Application.Features.Corp.Companies.Commands.Create;
using Application.Features.Corp.Companies.Commands.Delete;
using Application.Features.Corp.Companies.Commands.Update;
using Application.Features.Corp.Companies.Queries.GetById;
using Application.Features.Corp.Companies.Queries.GetList;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCompanyCommand)
    {
        CreatedCompanyResponse? response = await Mediator.Send(createCompanyCommand);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCompanyCommand deleteCompanyCommand)
    {
        DeletedCompanyResponse? response = await Mediator.Send(deleteCompanyCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
    {
        UpdatedCompanyResponse? response = await Mediator.Send(updateCompanyCommand);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListCompanyQuery getListCompanyQuery)
    {
        GetListResponse<GetListCompanyResponse>? response = await Mediator.Send(getListCompanyQuery);
        return Ok(response);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetById([FromQuery] GetCompanyQuery dto)
    {
        GetCompanyResponse? response = await Mediator.Send(dto);
        return Ok(response);
    }
}
