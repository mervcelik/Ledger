using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Corp;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Features.Corp.Companies.Queries.GetById;

public class GetCompanyQuery : BaseQueryDto, IRequest<GetCompanyResponse>
{
}

public class GetCompanyQueryHandler : BaseHandlerManager<Company>, IRequestHandler<GetCompanyQuery, GetCompanyResponse>
{
    public GetCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper) : base(companyRepository, mapper)
    {
    }
    public async Task<GetCompanyResponse> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Company, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetCompanyResponse>(predicate, cancellationToken: cancellationToken);
    }
}
