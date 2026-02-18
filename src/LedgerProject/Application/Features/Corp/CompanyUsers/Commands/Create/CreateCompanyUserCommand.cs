using Application.Features.Corp.CompanyUsers.Rules;
using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.CompanyUsers.Commands.Create;

public class CreateCompanyUserCommand : BaseCommandDto, IRequest<CreatedCompanyUserResponse>
{
    public int UserId { get; set; }
    public int CompanyId { get; set; }
}

public class CreateCompanyUserCommandHandler : BaseHandlerManager<CompanyUser>, IRequestHandler<CreateCompanyUserCommand, CreatedCompanyUserResponse>
{
    private readonly CompanyUserBusinessRules _companyUserBusinessRules;

    public CreateCompanyUserCommandHandler(
        IMapper mapper, 
        ICompanyUserRepository companyUserRepository, 
        CompanyUserBusinessRules companyUserBusinessRules) 
        : base(companyUserRepository, mapper)
    {
        _companyUserBusinessRules = companyUserBusinessRules;
    }

    public async Task<CreatedCompanyUserResponse> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
    {
        await _companyUserBusinessRules.CompanyMustExist(request.CompanyId);
        await _companyUserBusinessRules.UserMustExist(request.UserId);
        await _companyUserBusinessRules.CompanyUserMustBeUniqueWhenCreating(request.UserId, request.CompanyId);

        return await CreateAsync<CreatedCompanyUserResponse>(request, cancellationToken);
    }
}
