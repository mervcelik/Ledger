using Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Finance;

public class CurrentMovementDetailConfiguration : IEntityTypeConfiguration<CurrentMovementDetail>
{
    public void Configure(EntityTypeBuilder<CurrentMovementDetail> builder)
    {
        builder.ToTable("CurrentMovementDetails", "Finance").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.CurrentMovementId).HasColumnName("CurrentMovementId").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        builder.Property(x => x.Quantity).HasColumnName("Quantity").HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.Amount).HasColumnName("Amount").HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.TaxPercient).HasColumnName("TaxPercient").IsRequired();
        builder.Property(x => x.TotalAmount).HasColumnName("TotalAmount").HasPrecision(18, 2).IsRequired();

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        builder.HasOne(x => x.CurrentMovement)
               .WithMany(cm => cm.CurrentMovementDetails)
               .HasForeignKey(x => x.CurrentMovementId);
    }
}