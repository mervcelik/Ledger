using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.MovementTypes.Commands.Create;

public class CreateMovementTypeCommand : BaseCommandDto, IRequest<CreatedMovementTypeResponse>
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
}
public class CreateMovementTypeCommandHandler : BaseHandlerManager<MovementType>, IRequestHandler<CreateMovementTypeCommand, CreatedMovementTypeResponse>
{
    public CreateMovementTypeCommandHandler(IMapper mapper, IMovementTypeRepository MovementTypeRepository) : base(MovementTypeRepository, mapper)
    {

    }
    public async Task<CreatedMovementTypeResponse> Handle(CreateMovementTypeCommand request, CancellationToken cancellationToken)
    {
        return await CreateAsync<CreatedMovementTypeResponse>(request, cancellationToken);
    }
}
