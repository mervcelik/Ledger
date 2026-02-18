using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.CompanyUsers.Commands.Delete;

public class DeleteCompanyUserCommand : BaseCommandDto, IRequest<DeletedCompanyUserResponse>
{
}

public class DeleteCompanyUserCommandHandler : BaseHandlerManager<CompanyUser>, IRequestHandler<DeleteCompanyUserCommand, DeletedCompanyUserResponse>
{
    public DeleteCompanyUserCommandHandler(ICompanyUserRepository companyUserRepository, IMapper mapper) 
        : base(companyUserRepository, mapper)
    {
    }

    public async Task<DeletedCompanyUserResponse> Handle(DeleteCompanyUserCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedCompanyUserResponse>(request, false, cancellationToken);
    }
}
