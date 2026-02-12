using Application.Features.Finance.CurrentMovementDetails.Commands.Create;
using Application.Features.Finance.CurrentMovementDetails.Commands.Delete;
using Application.Features.Finance.CurrentMovementDetails.Commands.Update;
using Application.Features.Finance.CurrentMovementDetails.Queries.Get;
using Application.Features.Finance.CurrentMovementDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<CurrentMovementDetail, CreateCurrentMovementDetailCommand>().ReverseMap();
        CreateMap<CurrentMovementDetail, CreatedCurrentMovementDetailResponse>().ReverseMap();
        CreateMap<CurrentMovementDetail, DeleteCurrentMovementDetailCommand>().ReverseMap();
        CreateMap<CurrentMovementDetail, DeletedCurrentMovementDetailResponse>().ReverseMap();
        CreateMap<CurrentMovementDetail, UpdateCurrentMovementDetailCommand>().ReverseMap();
        CreateMap<CurrentMovementDetail, UpdatedCurrentMovementDetailResponse>().ReverseMap();
        CreateMap<CurrentMovementDetail, GetListCurrentMovementDetailResponse>().ReverseMap();
        CreateMap<Paginate<CurrentMovementDetail>, GetListResponse<GetListCurrentMovementDetailResponse>>().ReverseMap();
        CreateMap<CurrentMovementDetail, GetCurrentMovementDetailResponse>().ReverseMap();
    }
}
