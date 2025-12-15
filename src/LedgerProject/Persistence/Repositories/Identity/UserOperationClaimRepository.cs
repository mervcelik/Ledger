using Application.Repositories.Identity;
using Core.Persistence.Repositories;
using Domain.Entities.Identity;
using Persistence.Contexts;

namespace Persistence.Repositories.Identity;

public class UserOperationClaimRepository: EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
