using Application.Repositories.Finance;
using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using Persistence.Contexts;

namespace Persistence.Repositories.Finance;

public class CurrentMovementRepository : EfRepositoryBase<CurrentMovement, BaseDbContext>, ICurrentMovementRepository
{
    public CurrentMovementRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
