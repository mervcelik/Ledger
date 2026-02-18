using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Corp;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Corp.CompanyUsers.Queries.GetList;

public class GetListCompanyUserQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCompanyUserResponse>>
{
    public int? UserId { get; set; }
    public int? CompanyId { get; set; }
}

public class GetListCompanyUserQueryHandler : BaseHandlerManager<CompanyUser>, IRequestHandler<GetListCompanyUserQuery, GetListResponse<GetListCompanyUserResponse>>
{
    public GetListCompanyUserQueryHandler(ICompanyUserRepository companyUserRepository, IMapper mapper) 
        : base(companyUserRepository, mapper)
    {
    }

    public async Task<GetListResponse<GetListCompanyUserResponse>> Handle(GetListCompanyUserQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<CompanyUser, bool>>? predicate = x => x.Id > 0;
        if (request.UserId.HasValue)
        {
            predicate = predicate.And(x => x.UserId == request.UserId);
        }
        if (request.CompanyId.HasValue)
        {
            predicate = predicate.And(x => x.CompanyId == request.CompanyId);
        }

        return await GetListAsync<GetListCompanyUserResponse>(request, cancellationToken: cancellationToken);
    }
}
