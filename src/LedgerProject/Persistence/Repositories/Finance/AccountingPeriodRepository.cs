using Application.Repositories.Finance;
using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.Finance;

public class AccountingPeriodRepository: EfRepositoryBase<AccountingPeriod, BaseDbContext>, IAccountingPeriodRepository
{
    public AccountingPeriodRepository(BaseDbContext baseDbContext)
        : base(baseDbContext)
    {
    }
}
