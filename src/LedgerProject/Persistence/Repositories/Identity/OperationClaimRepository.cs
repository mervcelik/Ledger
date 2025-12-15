using Application.Repositories.Identity;
using Core.Persistence.Repositories;
using Domain.Entities.Identity;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.Identity;

public class OperationClaimRepository:EfRepositoryBase<OperationClaim,BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext baseDbContext): base(baseDbContext)
    {
        
    }
}
