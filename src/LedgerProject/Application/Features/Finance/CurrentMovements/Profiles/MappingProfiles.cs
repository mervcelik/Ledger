using Application.Features.Finance.CurrentMovements.Commands.Create;
using Application.Features.Finance.CurrentMovements.Commands.Delete;
using Application.Features.Finance.CurrentMovements.Commands.Update;
using Application.Features.Finance.CurrentMovements.Queries.Get;
using Application.Features.Finance.CurrentMovements.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CurrentMovement, CreateCurrentMovementCommand>().ReverseMap();
        CreateMap<CurrentMovement, CreatedCurrentMovementResponse>().ReverseMap();
        CreateMap<CurrentMovement, DeleteCurrentMovementCommand>().ReverseMap();
        CreateMap<CurrentMovement, DeletedCurrentMovementResponse>().ReverseMap();
        CreateMap<CurrentMovement, UpdateCurrentMovementCommand>().ReverseMap();
        CreateMap<CurrentMovement, UpdatedCurrentMovementResponse>().ReverseMap();
        CreateMap<CurrentMovement, GetListCurrentMovementResponse>().ReverseMap();
        CreateMap<Paginate<CurrentMovement>, GetListResponse<GetListCurrentMovementResponse>>().ReverseMap();
        CreateMap<CurrentMovement, GetCurrentMovementResponse>().ReverseMap();
    }
}
