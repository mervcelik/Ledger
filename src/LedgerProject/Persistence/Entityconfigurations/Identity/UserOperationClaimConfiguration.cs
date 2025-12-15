using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Identity;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims", "Identity").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User).WithMany(x=>x.UserOperationClaims).HasForeignKey(x=>x.UserId);
        builder.HasOne(uoc => uoc.OperationClaim).WithMany(x=>x.UserOperationClaims).HasForeignKey(x=>x.OperationClaimId);

      //  builder.HasData(getSeeds());
    }

    private IEnumerable<UserOperationClaim> getSeeds()
    {
        List<UserOperationClaim> userOperationClaims = new();

        UserOperationClaim adminUserOperationClaim = new()
        {
            Id = 1,
            UserId=1,
            OperationClaimId=1,
        };
        userOperationClaims.Add(adminUserOperationClaim);

        return userOperationClaims;
    }
}