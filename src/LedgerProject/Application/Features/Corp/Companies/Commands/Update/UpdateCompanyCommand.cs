using Application.Features.Corp.Companies.Rules;
using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.Companies.Commands.Update;

public class UpdateCompanyCommand:BaseCommandDto,IRequest<UpdatedCompanyResponse>
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? TaxNumber { get; set; }
    public string? PhoneNumber { get; set; }
}

public class UpdateCompanyCommandHandler : BaseHandlerManager<Company>, IRequestHandler<UpdateCompanyCommand, UpdatedCompanyResponse>
{
    private readonly CompanyBusinessRules _companyBusinessRules;
    public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules) : base(companyRepository, mapper)
    {
        _companyBusinessRules = companyBusinessRules;
    }
    public async Task<UpdatedCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyBusinessRules.CompanyNameMustBeUniqueWhenUpdating(request.Id, request.Name);

        return await UpdateAsync<UpdatedCompanyResponse>(request, cancellationToken);
    }
}