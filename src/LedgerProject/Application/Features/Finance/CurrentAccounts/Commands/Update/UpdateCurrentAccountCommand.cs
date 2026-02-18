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

namespace Application.Features.Finance.CurrentAccounts.Commands.Update;

public class UpdateCurrentAccountCommand : BaseCommandDto, IRequest<UpdatedCurrentAccountResponse>
{
    public string Name { get; set; }
    public string TaxNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
}

public class UpdateCurrentAccountCommandHandler : BaseHandlerManager<CurrentAccount> ,IRequestHandler<UpdateCurrentAccountCommand, UpdatedCurrentAccountResponse>
{
    CurrentAccountBusinessRules _currentAccountRules;
    
    public UpdateCurrentAccountCommandHandler(ICurrentAccountRepository currentAccountRepository, IMapper mapper, CurrentAccountBusinessRules currentAccountRules) : base(currentAccountRepository, mapper)
    {
        _currentAccountRules = currentAccountRules;
    }
    
    public async Task<UpdatedCurrentAccountResponse> Handle(UpdateCurrentAccountCommand request, CancellationToken cancellationToken)
    {
        await _currentAccountRules.TaxNumberMustBeUnique(request.TaxNumber, 0, request.Id);
        return await UpdateAsync<UpdatedCurrentAccountResponse>(request, cancellationToken);
    }
}
