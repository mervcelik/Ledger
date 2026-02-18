using Application.Features.Identity.OperationClaims.Commands.Create;
using Application.Features.Identity.OperationClaims.Commands.Delete;
using Application.Features.Identity.OperationClaims.Commands.Update;
using Application.Features.Identity.OperationClaims.Queries.GetById;
using Application.Features.Identity.OperationClaims.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Identity;

namespace Application.Features.Identity.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
        CreateMap<Paginate<OperationClaim>, GetListResponse<GetListOperationClaimResponse>>().ReverseMap();
        CreateMap<OperationClaim, GetOperationClaimResponse>().ReverseMap();
    }
}
