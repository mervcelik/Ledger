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

namespace Application.Features.Finance.CurrentAccounts.Queries.Get;

public class GetCurrentAccountQuery:BaseQueryDto, IRequest<GetCurrentAccountResponse>
{
}
public class GetCurrentAccountQueryHandler:BaseHandlerManager<CurrentAccount>,IRequestHandler<GetCurrentAccountQuery, GetCurrentAccountResponse>
{
    public GetCurrentAccountQueryHandler(ICurrentAccountRepository currentAccountRepository,IMapper mapper) : base(currentAccountRepository,mapper)
    {
    }
    public async Task<GetCurrentAccountResponse> Handle(GetCurrentAccountQuery request, CancellationToken cancellationToken)
    {
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetCurrentAccountResponse>(cancellationToken: cancellationToken);
    }
}