using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Core.CrossCuttingConcerns.Extensions;
using Domain.Entities.Corp;
using MediatR;
using System;
using System.Linq.Expressions;

namespace Application.Features.Corp.CompanyUsers.Queries.GetById;

public class GetCompanyUserQuery : BaseQueryDto, IRequest<GetCompanyUserResponse>
{
}

public class GetCompanyUserQueryHandler : BaseHandlerManager<CompanyUser>, IRequestHandler<GetCompanyUserQuery, GetCompanyUserResponse>
{
    public GetCompanyUserQueryHandler(ICompanyUserRepository companyUserRepository, IMapper mapper) 
        : base(companyUserRepository, mapper)
    {
    }

    public async Task<GetCompanyUserResponse> Handle(GetCompanyUserQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<CompanyUser, bool>>? predicate = x => x.Id > 0;
        if (request.Id != null)
        {
            predicate = predicate.And(x => x.Id == request.Id);
        }
        return await GetAsync<GetCompanyUserResponse>(predicate, cancellationToken: cancellationToken);
    }
}
