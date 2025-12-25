using Application.Features.Corp.Companies.Commands.Create;
using Application.Features.Finance.AccountingPeriods.Rules;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Commands.Create;

public class CreateAccountingPeriodCommand:BaseCommandDto,IRequest<CreatedAccountingPeriodResponse>
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
    public int CompanyId { get; set; }
}

public class CreateAccountingPeriodCommandHandler:BaseHandlerManager<AccountingPeriod>,IRequestHandler<CreateAccountingPeriodCommand, CreatedAccountingPeriodResponse>
{
    AccountingPeriodRules _accountingPeriodRules;
    public CreateAccountingPeriodCommandHandler(IAccountingPeriodRepository accountingPeriodRepository,IMapper mapper,AccountingPeriodRules accountingPeriodRules):base(accountingPeriodRepository,mapper)
    {
        _accountingPeriodRules=accountingPeriodRules;
    }

    public async Task<CreatedAccountingPeriodResponse> Handle(CreateAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
        await _accountingPeriodRules.AccountingPeriodDateRangeMustNotOverlap(request.StartDate,request.EndDate,request.CompanyId);
        await _accountingPeriodRules.AccountingNameMustBeUniqueWhenCreating(request.Name,request.CompanyId);

        return await CreateAsync<CreatedAccountingPeriodResponse>(request, cancellationToken);
    }
}
