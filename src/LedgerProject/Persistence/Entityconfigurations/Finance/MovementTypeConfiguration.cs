using Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Finance;

public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
{
    public void Configure(EntityTypeBuilder<MovementType> builder)
    {
        builder.ToTable("MovementTypes", "Finance").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CompanyId).HasColumnName("CompanyId").IsRequired();

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        //builder.HasOne(x => x.Company)
        //    .WithMany()
        //    .HasForeignKey(x => x.CompanyId);
    }
}