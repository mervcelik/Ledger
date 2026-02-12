using Application.Repositories.Finance;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Managers;
using Domain.Entities.Finance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.MovementTypes.Commands.Delete;

public class DeleteMovementTypeCommand : BaseCommandDto, IRequest<DeletedMovementTypeResponse>
{

}
public class DeleteMovementTypeCommandHandler : BaseHandlerManager<MovementType>, IRequestHandler<DeleteMovementTypeCommand, DeletedMovementTypeResponse>
{
    public DeleteMovementTypeCommandHandler(IMovementTypeRepository MovementTypeRepository, IMapper mapper) : base(MovementTypeRepository, mapper)
    {

    }
    public async Task<DeletedMovementTypeResponse> Handle(DeleteMovementTypeCommand request, CancellationToken cancellationToken)
    {
        return await DeleteAsync<DeletedMovementTypeResponse>(request, false, cancellationToken);
    }
}
