using Application.Repositories.Finance;
using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using Persistence.Contexts;

namespace Persistence.Repositories.Finance;

public class MovementTypeRepository : EfRepositoryBase<MovementType, BaseDbContext>, IMovementTypeRepository
{
    public MovementTypeRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
