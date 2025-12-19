using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Corp.Companies.Commands.Delete;

public class DeletedCompanyResponse:BaseResponseDto
{
    public int Id { get; set; }
}
