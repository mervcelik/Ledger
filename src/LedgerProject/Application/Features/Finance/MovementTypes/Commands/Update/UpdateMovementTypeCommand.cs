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
}
public class UpdateMovementTypeCommandHandler : BaseHandlerManager<MovementType>, IRequestHandler<UpdateMovementTypeCommand, UpdatedMovementTypeResponse>
{
    public UpdateMovementTypeCommandHandler(IMovementTypeRepository repository, IMapper mapper) : base(repository, mapper)
    {

    }

    public async Task<UpdatedMovementTypeResponse> Handle(UpdateMovementTypeCommand request, CancellationToken cancellationToken)
    {
        return await UpdateAsync<UpdatedMovementTypeResponse>(request, cancellationToken);
    }
}
