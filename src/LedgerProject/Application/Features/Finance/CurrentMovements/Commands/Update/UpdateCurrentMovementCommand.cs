using Application.Features.Finance.CurrentAccounts.Commands.Update;
using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Commands.Update;

public class UpdateCurrentMovementCommand : BaseCommandDto, IRequest<UpdatedCurrentMovementResponse>
{
    public string Description { get; set; }
    public string? DocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public Direction Direction { get; set; }
    public decimal Amount { get; set; }
    public int MovementTypeId { get; set; }
}
public class UpdateCurrentMovementCommandHandler : BaseHandlerManager<CurrentMovement>, IRequestHandler<UpdateCurrentMovementCommand, UpdatedCurrentMovementResponse>
{
    public UpdateCurrentMovementCommandHandler(ICurrentMovementRepository currentMovementRepository, IMapper mapper) : base(currentMovementRepository, mapper)
    {

    }
    public async Task<UpdatedCurrentMovementResponse> Handle(UpdateCurrentMovementCommand request, CancellationToken cancellationToken)
    {
        return await UpdateAsync<UpdatedCurrentMovementResponse>(request, cancellationToken);
    }
}
