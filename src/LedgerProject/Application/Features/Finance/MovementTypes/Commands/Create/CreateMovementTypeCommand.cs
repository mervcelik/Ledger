using Application.Features.Finance.MovementTypes.Rules;
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
    private readonly MovementTypeBusinessRules _movementTypeBusinessRules;

    public CreateMovementTypeCommandHandler(IMapper mapper, IMovementTypeRepository MovementTypeRepository, MovementTypeBusinessRules movementTypeBusinessRules) : base(MovementTypeRepository, mapper)
    {
        _movementTypeBusinessRules = movementTypeBusinessRules;
    }
    public async Task<CreatedMovementTypeResponse> Handle(CreateMovementTypeCommand request, CancellationToken cancellationToken)
    {
        // Business Rules Validations
        await _movementTypeBusinessRules.CompanyMustExist(request.CompanyId);
        await _movementTypeBusinessRules.MovementTypeNameCanNotBeDuplicatedWhenCreated(request.Name, request.CompanyId);

        return await CreateAsync<CreatedMovementTypeResponse>(request, cancellationToken);
    }
}

