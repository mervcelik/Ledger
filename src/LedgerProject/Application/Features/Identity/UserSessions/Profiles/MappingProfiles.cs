using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Identity;
using Application.Features.Identity.UserSessions.Commands.Create;
using Application.Features.Identity.UserSessions.Commands.Delete;
using Application.Features.Identity.UserSessions.Commands.Update;
using Application.Features.Identity.UserSessions.Queries.GetList;
using Application.Features.Identity.UserSessions.Queries.Get;

namespace Application.Features.Identity.UserSessions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserSession, CreateUserSessionCommand>().ReverseMap();
        CreateMap<UserSession, CreatedUserSessionResponse>().ReverseMap();

        CreateMap<UserSession, UpdateUserSessionCommand>().ReverseMap();
        CreateMap<UserSession, UpdatedUserSessionResponse>().ReverseMap();

        CreateMap<UserSession, DeleteUserSessionCommand>().ReverseMap();
        CreateMap<UserSession, DeletedUserSessionResponse>().ReverseMap();

        CreateMap<UserSession, GetListUserSessionResponse>().ReverseMap();
        CreateMap<Paginate<UserSession>, GetListResponse<GetListUserSessionResponse>>().ReverseMap();

        CreateMap<UserSession, GetUserSessionResponse>().ReverseMap();
    }
}
