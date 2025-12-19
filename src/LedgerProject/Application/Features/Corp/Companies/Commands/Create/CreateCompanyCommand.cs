using Application.Features.Corp.Companies.Rules;
using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.Companies.Commands.Create;

public class CreateCompanyCommand : BaseCommandDto, IRequest<CreatedCompanyResponse>
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? TaxNumber { get; set; }
    public string? PhoneNumber { get; set; }
}
public class CreateCompanyCommandHandler : BaseHandlerManager<Company>, IRequestHandler<CreateCompanyCommand, CreatedCompanyResponse>
{
    private readonly CompanyBusinessRules _companyBusinessRules;
    public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules) : base(companyRepository, mapper)
    {
        _companyBusinessRules = companyBusinessRules;
    }
    public async Task<CreatedCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyBusinessRules.CompanyNameMustBeUniqueWhenCreating(request.Name);

        return await CreateAsync<CreatedCompanyResponse>(request, cancellationToken );
    }
}