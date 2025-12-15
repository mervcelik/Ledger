using Application.Repositories.Finance;
using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using Persistence.Contexts;

namespace Persistence.Repositories.Finance;

public class CurrentMovementDetailRepository: EfRepositoryBase<CurrentMovementDetail, BaseDbContext>, ICurrentMovementDetailRepository
{
    public CurrentMovementDetailRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
