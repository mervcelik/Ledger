using Domain.Entities.Corp;
using Domain.Entities.Finance;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public IConfiguration Configuration { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    
    
    public DbSet<AccountingPeriod> AccountingPeriods { get; set; }
    public DbSet<CurrentAccount> CurrentAccounts { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<CurrentMovement> CurrentMovements { get; set; }
    public DbSet<CurrentMovementDetail> CurrentMovementDetails { get; set; }


}
