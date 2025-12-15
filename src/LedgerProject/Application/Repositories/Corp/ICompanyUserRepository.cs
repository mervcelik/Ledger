using Core.Persistence.Repositories;
using Domain.Entities.Corp;

namespace Application.Repositories.Corp;

public interface ICompanyUserRepository : IRepositoryAsync<CompanyUser>
{
}
