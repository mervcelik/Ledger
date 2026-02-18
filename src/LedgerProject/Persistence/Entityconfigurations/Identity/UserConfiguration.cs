using Core.Security.Hashing;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entityconfigurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "Identity").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserSessions)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.CompanyUsers)
            .WithOne(cu => cu.User)
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder.HasData(getSeeds());
    }

    //private IEnumerable<User> getSeeds()
    //{
    //    List<User> users = new();

    //    HashingHelper.CreatePasswordHash(
    //        password: "Passw0rd",
    //        passwordHash: out byte[] passwordHash,
    //        passwordSalt: out byte[] passwordSalt
    //    );
    //    User adminUser =
    //        new()
    //        {
    //            Id = 1,
    //            FirstName = "Admin",
    //            LastName = "Admin",
    //            UserName = "admin",
    //            Status = true,
    //            PasswordHash = passwordHash,
    //            PasswordSalt = passwordSalt
    //        };
    //    users.Add(adminUser);

    //    return users.ToArray();
    //}
}