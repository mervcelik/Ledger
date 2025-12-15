using Core.Persistence.Repositories;
using Domain.Entities.Identity;

namespace Application.Repositories.Identity;

public interface IUserSessionRepository : IRepositoryAsync<UserSession>
{
}
