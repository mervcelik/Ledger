using Core.Persistence.Repositories;
using Domain.Entities.Finance;

namespace Application.Repositories.Finance;

public interface ICurrentMovementRepository : IRepositoryAsync<CurrentMovement>
{
}
