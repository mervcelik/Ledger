using Application.Repositories.Identity;
using Core.Persistence.Repositories;
using Domain.Entities.Identity;
using Persistence.Contexts;

namespace Persistence.Repositories.Identity;

public class UserRepository: EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
