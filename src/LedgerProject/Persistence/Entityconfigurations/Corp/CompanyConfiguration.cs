using Domain.Entities.Corp;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Entityconfigurations.Corp;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "Corp").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Address).HasColumnName("Address");
        builder.Property(x => x.TaxNumber).HasColumnName("TaxNumber");
        builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        builder.HasMany(x => x.CompanyUsers);
        builder.HasMany(x => x.AccountingPeriods);
        builder.HasMany(x => x.CurrentAccounts);
        builder.HasMany(x => x.CurrentMovements);
        builder.HasMany(x => x.MovementTypes);
    }
}
