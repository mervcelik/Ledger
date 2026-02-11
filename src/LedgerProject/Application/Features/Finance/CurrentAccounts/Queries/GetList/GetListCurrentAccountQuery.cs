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

public class GetListCurrentAccountQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCurrentAccountResponse>>
{
    public int? CompanyId { get; set; }
}

public class GetListCurrentAccountQueryHandler : BaseHandlerManager<CurrentAccount>, IRequestHandler<GetListCurrentAccountQuery, GetListResponse<GetListCurrentAccountResponse>>
{
    public GetListCurrentAccountQueryHandler(ICurrentAccountRepository currentAccountRepository, IMapper mapper) :base(currentAccountRepository, mapper: mapper)
    {

    }

    public async Task<GetListResponse<GetListCurrentAccountResponse>> Handle(GetListCurrentAccountQuery request, CancellationToken cancellationToken)
    {
        if (request.CompanyId != null)
        {
            predicate = predicate.And(f => f.CompanyId == request.CompanyId);
        }
        return await GetListAsync<GetListCurrentAccountResponse>(request, cancellationToken: cancellationToken);
    }
}