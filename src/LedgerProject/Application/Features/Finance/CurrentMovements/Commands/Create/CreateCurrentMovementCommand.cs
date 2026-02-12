using Application.Features.Finance.CurrentAccounts.Commands.Create;
using Application.Features.Finance.CurrentAccounts.Rules;
using Application.Features.Finance.CurrentMovements.Rules;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Corp;
using Domain.Entities.Finance;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Commands.Create;

public class CreateCurrentMovementCommand:BaseCommandDto, IRequest<CreatedCurrentMovementResponse>
{
    public int CurrentAccountId { get; set; }
    public int AccountingPeriodId { get; set; }
    public int CompanyId { get; set; }
    public string Description { get; set; }
    public string? DocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public Direction Direction { get; set; }
    public decimal Amount { get; set; }
    public int MovementTypeId { get; set; }
}
public class CreateCurrentMovementCommandHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<CreateCurrentMovementCommand, CreatedCurrentMovementResponse>
{
    CurrentMovementBusinessRules _currentMovementRules;
    public CreateCurrentMovementCommandHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper, CurrentMovementBusinessRules currentMovementRules) : base(currentMovementRepository, mapper)
    {
        _currentMovementRules = currentMovementRules;
    }
    public async Task<CreatedCurrentMovementResponse> Handle(CreateCurrentMovementCommand request, CancellationToken cancellationToken)
    {
        return await CreateAsync<CreatedCurrentMovementResponse>(request, cancellationToken);
    }
}
