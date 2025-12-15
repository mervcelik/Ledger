using Application.Repositories.Corp;
using Core.Persistence.Repositories;
using Domain.Entities.Corp;
using Persistence.Contexts;

namespace Persistence.Repositories.Corp;

public class CompanyUserRepository: EfRepositoryBase<CompanyUser, BaseDbContext>, ICompanyUserRepository
{
    public CompanyUserRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}