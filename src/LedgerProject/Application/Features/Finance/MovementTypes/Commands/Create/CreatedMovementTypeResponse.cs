using Core.Application.Dtos;

namespace Application.Features.Finance.MovementTypes.Commands.Create;

public class CreatedMovementTypeResponse:BaseResponseDto
{
    public int Id { get; set; }
}