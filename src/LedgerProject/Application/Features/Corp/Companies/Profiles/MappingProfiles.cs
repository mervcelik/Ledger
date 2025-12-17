using Application.Features.Corp.Companies.Commands.Create;
using Core.Persistence.Paging;
using Domain.Entities.Corp;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace Application.Features.Corp.Companies.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CreatedCompanyResponse>().ReverseMap();
    }
}
