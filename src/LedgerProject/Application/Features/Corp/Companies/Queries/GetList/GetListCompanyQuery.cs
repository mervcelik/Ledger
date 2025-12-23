using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Corp;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Corp.Companies.Queries.GetList;

public class GetListCompanyQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCompanyResponse>>
{
    public string? ContainsName { get; set; }
    public string? ContainsTaxNumber { get; set; }
}

public class GetListCompanyQueryHandler : BaseHandlerManager<Company>, IRequestHandler<GetListCompanyQuery, GetListResponse<GetListCompanyResponse>>
{
    public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper) : base(companyRepository, mapper)
    {
    }
    public async Task<GetListResponse<GetListCompanyResponse>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.ContainsName))
        {
            predicate = predicate.And(x => x.Name.Contains(request.ContainsName));
        }
        if (!string.IsNullOrEmpty(request.ContainsTaxNumber))
        {
            predicate = predicate.And(x => x.TaxNumber.Contains(request.ContainsTaxNumber));
        }

        return await GetListAsync<GetListCompanyResponse>(request,cancellationToken: cancellationToken);
    }
}