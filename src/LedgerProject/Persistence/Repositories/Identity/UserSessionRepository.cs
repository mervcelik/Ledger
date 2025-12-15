using Application.Repositories.Identity;
using Core.Persistence.Repositories;
using Domain.Entities.Identity;
using Persistence.Contexts;

namespace Persistence.Repositories.Identity;

public class UserSessionRepository: EfRepositoryBase<UserSession, BaseDbContext>, IUserSessionRepository
{
    public UserSessionRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
