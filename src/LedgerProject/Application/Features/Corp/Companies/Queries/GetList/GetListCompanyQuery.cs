using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.Companies.Queries.GetList;

public class GetListCompanyQuery : BaseListQueryDto, IRequest<GetListResponse<GetListCompanyResponse>>
{

}

public class GetListCompanyQueryHandler :BaseHandlerManager<Company> ,IRequestHandler<GetListCompanyQuery, GetListResponse<GetListCompanyResponse>>
{
    public GetListCompanyQueryHandler(ICompanyRepository companyRepository,IMapper mapper):base(companyRepository,mapper)
    {
    }
    public async Task<GetListResponse<GetListCompanyResponse>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetListAsync();
        return await GetListAsync<GetListCompanyResponse>(request, cancellationToken);
    }
}