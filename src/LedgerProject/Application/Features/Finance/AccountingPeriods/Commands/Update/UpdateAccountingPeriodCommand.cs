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

namespace Application.Features.Finance.AccountingPeriods.Commands.Update;

public class UpdateAccountingPeriodCommand:BaseCommandDto,IRequest<UpdatedAccountingPeriodResponse>
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
    public int CompanyId { get; set; }
}
public class UpdateAccountingPeriodCommandHandler:BaseHandlerManager<AccountingPeriod>,IRequestHandler<UpdateAccountingPeriodCommand, UpdatedAccountingPeriodResponse>
{
    AccountingPeriodRules _accountingPeriodRules;
    public UpdateAccountingPeriodCommandHandler(IAccountingPeriodRepository accountingPeriodRepository,IMapper mapper,AccountingPeriodRules accountingPeriodRules):base(accountingPeriodRepository,mapper)
    {
        _accountingPeriodRules=accountingPeriodRules;
    }
    public async Task<UpdatedAccountingPeriodResponse> Handle(UpdateAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
        await _accountingPeriodRules.AccountingPeriodDateRangeMustNotOverlapUpdating(Convert.ToInt32(request.Id),request.StartDate,request.EndDate,request.CompanyId);
        await _accountingPeriodRules.AccountingNameMustBeUniqueWhenUpdating(Convert.ToInt32(request.Id), request.Name,request.CompanyId);

        return await UpdateAsync<UpdatedAccountingPeriodResponse>(request, cancellationToken);
    }
}
