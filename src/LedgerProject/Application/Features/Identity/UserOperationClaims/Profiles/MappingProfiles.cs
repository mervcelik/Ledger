using Application.Features.Identity.UserOperationClaims.Commands.Create;
using Application.Features.Identity.UserOperationClaims.Commands.Delete;
using Application.Features.Identity.UserOperationClaims.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Identity;

namespace Application.Features.Identity.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>().ReverseMap();
        CreateMap<Paginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimResponse>>().ReverseMap();
    }
}
