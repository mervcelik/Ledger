using Core.Application.Dtos;

namespace Application.Features.Finance.CurrentAccounts.Commands.Create;

public class CreatedCurrentAccountResponse: BaseResponseDto
{
    public int Id { get; set; }
}
