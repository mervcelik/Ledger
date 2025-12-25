using Application.Features.Finance.AccountingPeriods.Commands.Create;
using Application.Features.Finance.AccountingPeriods.Commands.Delete;
using Application.Features.Finance.AccountingPeriods.Commands.Update;
using Application.Features.Finance.AccountingPeriods.Queries.Get;
using Application.Features.Finance.AccountingPeriods.Queries.GetList;
using Application.Features.Finance.CurrentAccounts.Queries.Get;
using Application.Features.Finance.CurrentAccounts.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateMap<CurrentAccount, CreateCurrentAccountCommand>().ReverseMap();
        //CreateMap<CurrentAccount, CreatedCurrentAccountResponse>().ReverseMap();
        //CreateMap<CurrentAccount, DeleteCurrentAccountCommand>().ReverseMap();
        //CreateMap<CurrentAccount, DeletedCurrentAccountResponse>().ReverseMap();
        //CreateMap<CurrentAccount, UpdateCurrentAccountCommand>().ReverseMap();
        //CreateMap<CurrentAccount, UpdatedCurrentAccountResponse>().ReverseMap();
        CreateMap<CurrentAccount, GetListCurrentAccountResponse>().ReverseMap();
        CreateMap<Paginate<CurrentAccount>, GetListResponse<GetListCurrentAccountResponse>>().ReverseMap();
        CreateMap<CurrentAccount, GetCurrentAccountResponse>().ReverseMap();
    }
}
