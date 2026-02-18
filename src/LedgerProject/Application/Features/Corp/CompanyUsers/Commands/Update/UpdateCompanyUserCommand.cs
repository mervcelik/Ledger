using Application.Features.Corp.CompanyUsers.Rules;
using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.CompanyUsers.Commands.Update;

public class UpdateCompanyUserCommand : BaseCommandDto, IRequest<UpdatedCompanyUserResponse>
{
    public int UserId { get; set; }
    public int CompanyId { get; set; }
}

public class UpdateCompanyUserCommandHandler : BaseHandlerManager<CompanyUser>, IRequestHandler<UpdateCompanyUserCommand, UpdatedCompanyUserResponse>
{
    private readonly CompanyUserBusinessRules _companyUserBusinessRules;

    public UpdateCompanyUserCommandHandler(
        IMapper mapper, 
        ICompanyUserRepository companyUserRepository, 
        CompanyUserBusinessRules companyUserBusinessRules) 
        : base(companyUserRepository, mapper)
    {
        _companyUserBusinessRules = companyUserBusinessRules;
    }

    public async Task<UpdatedCompanyUserResponse> Handle(UpdateCompanyUserCommand request, CancellationToken cancellationToken)
    {
        await _companyUserBusinessRules.CompanyMustExist(request.CompanyId);
        await _companyUserBusinessRules.UserMustExist(request.UserId);

        return await UpdateAsync<UpdatedCompanyUserResponse>(request, cancellationToken);
    }
}
