using Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Finance;

public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>
{
    public void Configure(EntityTypeBuilder<CurrentAccount> builder)
    {
        builder.ToTable("CurrentAccounts", "Finance").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.TaxNumber).HasColumnName("TaxNumber").IsRequired();
        builder.Property(x => x.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email");
        builder.Property(x => x.Address).HasColumnName("Address");
        builder.Property(x => x.Phone).HasColumnName("Phone");

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        //builder.HasOne(x => x.Company)
        //       .WithMany(c => c.CurrentAccounts)
        //       .HasForeignKey(x => x.CompanyId);
    }
}