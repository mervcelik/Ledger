using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Application.Features.Finance.AccountingPeriods.Queries.Get.GetAccountingPeriodQueryHandler;

namespace Application.Features.Finance.AccountingPeriods.Queries.Get;

public class GetAccountingPeriodQuery : BaseQueryDto, IRequest<GetAccountingPeriodResponse>
{
}
public class GetAccountingPeriodQueryHandler : BaseHandlerManager<AccountingPeriod>, IRequestHandler<GetAccountingPeriodQuery, GetAccountingPeriodResponse>
{
    public GetAccountingPeriodQueryHandler(IMapper mapper, IAccountingPeriodRepository accountingPeriodRepository) : base(accountingPeriodRepository, mapper)
    {
    }
    public async Task<GetAccountingPeriodResponse> Handle(GetAccountingPeriodQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<AccountingPeriod, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetAccountingPeriodResponse>(predicate,cancellationToken: cancellationToken);
    }
}
