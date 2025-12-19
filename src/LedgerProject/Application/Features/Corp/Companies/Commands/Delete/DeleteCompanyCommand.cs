using Application.Repositories.Corp;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using MediatR;

namespace Application.Features.Corp.Companies.Commands.Delete;

public class DeleteCompanyCommand: BaseCommandDto, IRequest<DeletedCompanyResponse>
{
}
public class DeleteCompanyCommandHandler : BaseHandlerManager<Company>, IRequestHandler<DeleteCompanyCommand, DeletedCompanyResponse>
{
    public DeleteCompanyCommandHandler(ICompanyRepository CompanyRepository, IMapper mapper):base(CompanyRepository, mapper)
    {
    }
    public async Task<DeletedCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
      return await DeleteAsync<DeletedCompanyResponse>(request,false,cancellationToken);
    }
}