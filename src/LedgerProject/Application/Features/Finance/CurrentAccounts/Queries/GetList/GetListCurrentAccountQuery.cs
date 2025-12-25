using Application.Features.Finance.AccountingPeriods.Queries.GetList;
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

namespace Application.Features.Finance.CurrentAccounts.Queries.GetList;

public class GetListCurrentAccountQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCurrentAccountQuery>>
{
    public int? CompanyId { get; set; }
}

public class GetListCurrentAccountQueryHandler : BaseHandlerManager<CurrentAccount>, IRequestHandler<GetListCurrentAccountQuery, GetListResponse<GetListCurrentAccountQuery>>
{
    public GetListCurrentAccountQueryHandler(ICurrentAccountRepository currentAccountRepository, IMapper mapper) :base(currentAccountRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListCurrentAccountQuery>> Handle(GetListCurrentAccountQuery request, CancellationToken cancellationToken)
    {
        if (request.CompanyId != null)
        {
            predicate = predicate.And(f => f.CompanyId == request.CompanyId);
        }
        return await GetListAsync<GetListCurrentAccountQuery>(request, cancellationToken: cancellationToken);
    }
}