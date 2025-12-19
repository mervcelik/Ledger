using Application.Features.Corp.Companies.Commands.Create;
using Application.Features.Corp.Companies.Commands.Delete;
using Application.Features.Corp.Companies.Commands.Update;
using Application.Features.Corp.Companies.Queries.GetById;
using Application.Features.Corp.Companies.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Corp;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Features.Corp.Companies.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CreatedCompanyResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
        CreateMap<Company, DeletedCompanyResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
        CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();
        CreateMap<Company, GetListCompanyResponse>().ReverseMap();
        CreateMap<Paginate<Company>, GetListResponse<GetListCompanyResponse>>().ReverseMap();
        CreateMap<Company, GetCompanyResponse>().ReverseMap();
    }
}
