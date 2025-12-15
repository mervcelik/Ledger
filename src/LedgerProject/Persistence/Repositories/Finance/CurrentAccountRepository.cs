using Application.Repositories.Finance;
using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using Persistence.Contexts;

namespace Persistence.Repositories.Finance;

public class CurrentAccountRepository: EfRepositoryBase<CurrentAccount, BaseDbContext>, ICurrentAccountRepository
{
    public CurrentAccountRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
