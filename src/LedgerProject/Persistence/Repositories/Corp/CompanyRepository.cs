using Application.Repositories.Corp;
using Core.Persistence.Repositories;
using Domain.Entities.Corp;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.Corp;

public class CompanyRepository: EfRepositoryBase<Company, BaseDbContext>, ICompanyRepository
{
    public CompanyRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
