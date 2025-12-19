using Core.Application.Dtos;
using Domain.Entities.Corp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Queries.GetList;

public class GetListCompanyResponse:BaseResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
