using Core.Application.Dtos;

namespace Application.Features.Finance.CurrentMovements.Commands.Create;

public class CreatedCurrentMovementResponse: BaseResponseDto
{
    public int Id { get; set; }
}