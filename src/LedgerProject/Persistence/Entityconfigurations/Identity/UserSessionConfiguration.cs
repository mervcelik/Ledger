using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Identity;

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("UserSessions", "Identity").HasKey(x => x.Id);

        builder.Property(oc => oc.AccessToken).HasColumnName("AccessToken").IsRequired();
        builder.Property(oc => oc.RefreshToken).HasColumnName("RefreshToken").IsRequired();
        builder.Property(oc => oc.ExpirationDate).HasColumnName("ExpirationDate").IsRequired();
        builder.Property(oc => oc.LogoutDate).HasColumnName("LogoutDate");
        builder.Property(oc => oc.Description).HasColumnName("Description");

        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        builder.HasOne(oc => oc.User)
            .WithMany(u => u.UserSessions)
            .HasForeignKey(oc => oc.UserId);
    }
}