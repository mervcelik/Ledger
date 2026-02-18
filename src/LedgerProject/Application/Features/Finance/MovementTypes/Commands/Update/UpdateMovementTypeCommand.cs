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

namespace Application.Features.Finance.MovementTypes.Commands.Update;

public class UpdateMovementTypeCommand : BaseCommandDto, IRequest<UpdatedMovementTypeResponse>
{
    public string Name { get; set; }
    public int CompanyId { get; set; }
}
public class UpdateMovementTypeCommandHandler : BaseHandlerManager<MovementType>, IRequestHandler<UpdateMovementTypeCommand, UpdatedMovementTypeResponse>
{
    private readonly MovementTypeBusinessRules _movementTypeBusinessRules;

    public UpdateMovementTypeCommandHandler(IMovementTypeRepository repository, IMapper mapper, MovementTypeBusinessRules movementTypeBusinessRules) : base(repository, mapper)
    {
        _movementTypeBusinessRules = movementTypeBusinessRules;
    }

    public async Task<UpdatedMovementTypeResponse> Handle(UpdateMovementTypeCommand request, CancellationToken cancellationToken)
    {
        // Business Rules Validations
        await _movementTypeBusinessRules.CompanyMustExist(request.CompanyId);
        await _movementTypeBusinessRules.MovementTypeNameCanNotBeDuplicatedWhenUpdated(Convert.ToInt32(request.Id), request.Name, request.CompanyId);

        return await UpdateAsync<UpdatedMovementTypeResponse>(request, cancellationToken);
    }
}

