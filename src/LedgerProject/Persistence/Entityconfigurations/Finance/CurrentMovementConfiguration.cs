using Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Finance;

public class CurrentMovementConfiguration : IEntityTypeConfiguration<CurrentMovement>
{
    public void Configure(EntityTypeBuilder<CurrentMovement> builder)
    {
        builder.ToTable("CurrentMovements", "Finance").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.CurrentAccountId).HasColumnName("CurrentAccountId").IsRequired();
        builder.Property(x => x.AccountingPeriodId).HasColumnName("AccountingPeriodId").IsRequired();
        builder.Property(x => x.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("DocumentNumber");
        builder.Property(x => x.Date).HasColumnName("Date").IsRequired();
        builder.Property(x => x.Direction).HasColumnName("Direction").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("Amount").HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.MovementTypeId).HasColumnName("MovementTypeId").IsRequired();

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        builder.HasOne(x => x.CurrentAccount)
               .WithMany(ca => ca.CurrentMovements)
               .HasForeignKey(x => x.CurrentAccountId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.AccountingPeriod)
               .WithMany(ap => ap.CurrentMovements)
               .HasForeignKey(x => x.AccountingPeriodId).OnDelete(DeleteBehavior.NoAction);

        //builder.HasOne(x => x.Company)
        //        .WithMany(c => c.CurrentMovements)
        //        .HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.MovementType)
                .WithMany(mt => mt.CurrentMovements)
                .HasForeignKey(x => x.MovementTypeId).OnDelete(DeleteBehavior.NoAction);
    }
}