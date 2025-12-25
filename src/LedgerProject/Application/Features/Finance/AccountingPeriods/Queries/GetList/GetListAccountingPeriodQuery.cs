using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Queries.GetList;

public class GetListAccountingPeriodQuery : BaseListQueryDto, IRequest<GetListResponse<GetListAccountingPeriodResponse>>
{
    public int? CompanyId { get; set; }
}

public class GetListAccountingPeriodQueryHandler : BaseHandlerManager<AccountingPeriod> ,IRequestHandler<GetListAccountingPeriodQuery, GetListResponse<GetListAccountingPeriodResponse>>
{
    public GetListAccountingPeriodQueryHandler(IAccountingPeriodRepository accountingPeriodRepository, IMapper mapper) : base(accountingPeriodRepository, mapper)
    {

    }
    public async Task<GetListResponse<GetListAccountingPeriodResponse>> Handle(GetListAccountingPeriodQuery request, CancellationToken cancellationToken)
    {
        if (request.CompanyId != null)
        {
            predicate=predicate.And(f => f.CompanyId == request.CompanyId);
        }
        return await GetListAsync<GetListAccountingPeriodResponse>(request, cancellationToken: cancellationToken);
    }
}
