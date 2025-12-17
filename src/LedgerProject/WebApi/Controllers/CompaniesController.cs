using Application.Features.Corp.Companies.Commands.Create;
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
}
