using Core.Application.Dtos;

namespace Application.Features.Finance.CurrentMovementDetails.Commands.Create;

public class CreatedCurrentMovementDetailResponse:BaseResponseDto
{
    public int Id { get; set; }
}