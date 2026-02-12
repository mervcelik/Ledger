using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Update;

public class UpdateCurrentMovementDetailCommand : BaseCommandDto, IRequest<UpdatedCurrentMovementDetailResponse>
{
    public int CurrentMovementId { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Amount { get; set; }
    public int TaxPercient { get; set; }
    public decimal TotalAmount { get; set; }
}
public class UpdateCurrentMovementDetailCommandHandler : BaseHandlerManager<CurrentMovementDetail>, IRequestHandler<UpdateCurrentMovementDetailCommand, UpdatedCurrentMovementDetailResponse>
{
    public UpdateCurrentMovementDetailCommandHandler(ICurrentMovementDetailRepository repository, IMapper mapper) : base(repository, mapper)
    {

    }

    public async Task<UpdatedCurrentMovementDetailResponse> Handle(UpdateCurrentMovementDetailCommand request, CancellationToken cancellationToken)
    {
        return await UpdateAsync<UpdatedCurrentMovementDetailResponse>(request, cancellationToken);
    }
}
