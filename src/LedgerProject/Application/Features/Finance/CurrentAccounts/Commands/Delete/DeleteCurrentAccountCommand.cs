using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentAccounts.Commands.Delete;

public class DeleteCurrentAccountCommand : BaseCommandDto, IRequest<DeletedCurrentAccountResponse>
{
}
public class DeleteCurrentAccountCommandHandler : BaseHandlerManager<CurrentAccount>, IRequestHandler<DeleteCurrentAccountCommand, DeletedCurrentAccountResponse>
{
    public DeleteCurrentAccountCommandHandler(ICurrentAccountRepository currentAccountRepository, IMapper mapper) : base(currentAccountRepository, mapper)
    {

    }
    public async Task<DeletedCurrentAccountResponse> Handle(DeleteCurrentAccountCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedCurrentAccountResponse>(request,false,cancellationToken);
    }
}