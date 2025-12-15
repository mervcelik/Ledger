using Core.Persistence.Repositories;
using Domain.Entities.Identity;

namespace Application.Repositories.Identity;

public interface IOperationClaimRepository : IRepositoryAsync<OperationClaim>
{
}
