using Application.Features.Finance.CurrentAccounts.Rules;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentAccounts.Commands.Create;

public class CreateCurrentAccountCommand : BaseCommandDto, IRequest<CreatedCurrentAccountResponse>
{
    public string Name { get; set; }
    public string TaxNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
}

public class CreateCurrentAccountCommandHandler : BaseHandlerManager<CurrentAccount>, IRequestHandler<CreateCurrentAccountCommand, CreatedCurrentAccountResponse>
{
    CurrentAccountRules _currentAccountRules;
    public CreateCurrentAccountCommandHandler(ICurrentAccountRepository currentAccountRepository, IMapper mapper, CurrentAccountRules currentAccountRules) : base(currentAccountRepository, mapper)
    {
        _currentAccountRules = currentAccountRules;
    }
    public async Task<CreatedCurrentAccountResponse> Handle(CreateCurrentAccountCommand request, CancellationToken cancellationToken)
    {
        await _currentAccountRules.CurrentAccountNameCanNotBeDuplicatedWhenInserted(request.Name, request.CompanyId);
        return await CreateAsync<CreatedCurrentAccountResponse>(request, cancellationToken);
    }
}
