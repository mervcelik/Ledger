using Application.Features.Corp.CompanyUsers.Commands.Create;
using Application.Features.Corp.CompanyUsers.Commands.Delete;
using Application.Features.Corp.CompanyUsers.Commands.Update;
using Application.Features.Corp.CompanyUsers.Queries.GetById;
using Application.Features.Corp.CompanyUsers.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Corp;

namespace Application.Features.Corp.CompanyUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CompanyUser, CreateCompanyUserCommand>().ReverseMap();
        CreateMap<CompanyUser, CreatedCompanyUserResponse>().ReverseMap();
        CreateMap<CompanyUser, DeleteCompanyUserCommand>().ReverseMap();
        CreateMap<CompanyUser, DeletedCompanyUserResponse>().ReverseMap();
        CreateMap<CompanyUser, UpdateCompanyUserCommand>().ReverseMap();
        CreateMap<CompanyUser, UpdatedCompanyUserResponse>().ReverseMap();
        CreateMap<CompanyUser, GetListCompanyUserResponse>().ReverseMap();
        CreateMap<Paginate<CompanyUser>, GetListResponse<GetListCompanyUserResponse>>().ReverseMap();
        CreateMap<CompanyUser, GetCompanyUserResponse>().ReverseMap();
    }
}
