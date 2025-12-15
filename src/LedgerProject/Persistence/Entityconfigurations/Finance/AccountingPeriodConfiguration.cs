using Domain.Entities.Finance;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Entityconfigurations.Finance;

public class AccountingPeriodConfiguration : IEntityTypeConfiguration<AccountingPeriod>
{
    public void Configure(EntityTypeBuilder<AccountingPeriod> builder)
    {
        builder.ToTable("AccountingPeriods", "Finance").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(x => x.IsClosed).HasColumnName("IsClosed").IsRequired();
        builder.Property(x => x.CompanyId).HasColumnName("CompanyId").IsRequired();

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        //builder.HasOne(x => x.Company)
        //       .WithMany(c => c.AccountingPeriods)
        //       .HasForeignKey(x => x.CompanyId);
    }
}
