using Application.Features.Finance.AccountingPeriods.Commands.Create;
using Application.Features.Finance.AccountingPeriods.Commands.Delete;
using Application.Features.Finance.AccountingPeriods.Commands.Update;
using Application.Features.Finance.AccountingPeriods.Queries.Get;
using Application.Features.Finance.AccountingPeriods.Queries.GetList;
using AutoMapper;
using Core.Application.Dtos;
using Core.Persistence.Paging;
using Domain.Entities.Corp;
using Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountingPeriod, CreateAccountingPeriodCommand>().ReverseMap();
        CreateMap<AccountingPeriod, CreatedAccountingPeriodResponse>().ReverseMap();
        CreateMap<AccountingPeriod, DeleteAccountingPeriodCommand>().ReverseMap();
        CreateMap<AccountingPeriod, DeletedAccountingPeriodResponse>().ReverseMap();
        CreateMap<AccountingPeriod, UpdateAccountingPeriodCommand>().ReverseMap();
        CreateMap<AccountingPeriod, UpdatedAccountingPeriodResponse>().ReverseMap();
        CreateMap<AccountingPeriod, GetListAccountingPeriodResponse>().ReverseMap();
        CreateMap<Paginate<AccountingPeriod>, GetListResponse<GetListAccountingPeriodResponse>>().ReverseMap();
        CreateMap<AccountingPeriod, GetAccountingPeriodResponse>().ReverseMap();
    }
}
