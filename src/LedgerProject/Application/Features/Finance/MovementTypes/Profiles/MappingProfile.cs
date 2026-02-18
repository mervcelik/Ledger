using Application.Features.Finance.MovementTypes.Commands.Create;
using Application.Features.Finance.MovementTypes.Commands.Delete;
using Application.Features.Finance.MovementTypes.Commands.Update;
using Application.Features.Finance.MovementTypes.Queries.Get;
using Application.Features.Finance.MovementTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Finance;

namespace Application.Features.Finance.MovementTypes.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovementType, CreateMovementTypeCommand>().ReverseMap();
        CreateMap<MovementType, CreatedMovementTypeResponse>().ReverseMap();
        CreateMap<MovementType, DeleteMovementTypeCommand>().ReverseMap();
        CreateMap<MovementType, DeletedMovementTypeResponse>().ReverseMap();
        CreateMap<MovementType, UpdateMovementTypeCommand>().ReverseMap();
        CreateMap<MovementType, UpdatedMovementTypeResponse>().ReverseMap();
        CreateMap<MovementType, GetListMovementTypeResponse>().ReverseMap();
        CreateMap<Paginate<MovementType>, GetListResponse<GetListMovementTypeResponse>>().ReverseMap();
        CreateMap<MovementType, GetMovementTypeResponse>().ReverseMap();
    }
}
