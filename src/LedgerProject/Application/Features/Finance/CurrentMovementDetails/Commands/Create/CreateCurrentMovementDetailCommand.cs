using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Create;

public class CreateCurrentMovementDetailCommand:BaseCommandDto,IRequest<CreatedCurrentMovementDetailResponse>
{
    public int CurrentMovementId { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Amount { get; set; }
    public int TaxPercient { get; set; }
    public decimal TotalAmount { get; set; }
}
public class CreateCurrentMovementDetailCommandHandler :BaseHandlerManager<CurrentMovementDetail>,IRequestHandler<CreateCurrentMovementDetailCommand, CreatedCurrentMovementDetailResponse>
{
    public CreateCurrentMovementDetailCommandHandler(IMapper mapper,ICurrentMovementDetailRepository currentMovementDetailRepository):base(currentMovementDetailRepository,mapper)
    {
        
    }
    public async Task<CreatedCurrentMovementDetailResponse> Handle(CreateCurrentMovementDetailCommand request, CancellationToken cancellationToken)
    {
        return await CreateAsync<CreatedCurrentMovementDetailResponse>(request, cancellationToken);
    }
}
