using Application.Features.Identity.Users.Commands.Create;
using Application.Features.Identity.Users.Commands.Delete;
using Application.Features.Identity.Users.Commands.Update;
using Application.Features.Identity.Users.Queries.Get;
using Application.Features.Identity.Users.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Identity;

namespace Application.Features.Identity.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserResponse>().ReverseMap();

        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();

        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();

        CreateMap<User, GetListUserResponse>().ReverseMap();
        CreateMap<Paginate<User>, GetListResponse<GetListUserResponse>>().ReverseMap();

        CreateMap<User, GetUserResponse>().ReverseMap();
    }
}
