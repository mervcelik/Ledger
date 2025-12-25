using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.AccountingPeriods.Commands.Delete;

public class DeleteAccountingPeriodCommand:BaseCommandDto ,IRequest<DeletedAccountingPeriodResponse>
{
}
public class DeleteAccountingPeriodCommandHandler : BaseHandlerManager<AccountingPeriod>, IRequestHandler<DeleteAccountingPeriodCommand, DeletedAccountingPeriodResponse>
{
    public DeleteAccountingPeriodCommandHandler(IAccountingPeriodRepository accountingPeriodRepository,IMapper mapper): base(accountingPeriodRepository,mapper)
    {
        
    }
    public async Task<DeletedAccountingPeriodResponse> Handle(DeleteAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
       return await DeleteAsync<DeletedAccountingPeriodResponse>(request,false,cancellationToken);
    }
}
