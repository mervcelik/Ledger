using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Commands.Update;

public class UpdatedCompanyResponse:BaseResponseDto
{

    public string Name { get; set; }
    public string? Address { get; set; }
    public string? TaxNumber { get; set; }
    public string? PhoneNumber { get; set; }
}
