using Application.Repositories.Corp;
using Application.Repositories.Finance;
using Application.Repositories.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Corp;
using Persistence.Repositories.Finance;
using Persistence.Repositories.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {

        // Corp
        services.AddTransient<ICompanyRepository, CompanyRepository>();
        services.AddTransient<ICompanyUserRepository, CompanyUserRepository>();

        // Finance
        services.AddTransient<IAccountingPeriodRepository, AccountingPeriodRepository>();
        services.AddTransient<ICurrentAccountRepository, CurrentAccountRepository>();
        services.AddTransient<ICurrentMovementRepository, CurrentMovementRepository>();
        services.AddTransient<ICurrentMovementDetailRepository, CurrentMovementDetailRepository>();
        services.AddTransient<IMovementTypeRepository, MovementTypeRepository>();

        // Identity
        services.AddTransient<IOperationClaimRepository, OperationClaimRepository>();
        services.AddTransient<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserSessionRepository, UserSessionRepository>();

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LedgerDB")));
        return services;
    }
}
