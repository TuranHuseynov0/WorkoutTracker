using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities.Auth;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AspNetUsers", table =>
            {
                table.HasCheckConstraint("CK_AppUsers_Weight", "\"Weight\" >= 0");
                table.HasCheckConstraint("CK_AppUsers_Height", "\"Height\" >= 0");
                table.HasCheckConstraint("CK_AppUsers_Counts",
                    "\"WorkoutCount\" >= 0 AND \"FollowersCount\" >= 0 AND \"FollowingCount\" >= 0");
                table.HasCheckConstraint("CK_AppUsers_Gender", "\"Gender\" IN (0, 1, 2)");
            });

            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Gender).IsRequired();
            builder.Property(user => user.BirthDate).HasColumnType("date").IsRequired();
            builder.Property(user => user.Bio).HasMaxLength(1000);
            builder.Property(user => user.SocialMediaLinks).HasMaxLength(2000);
            builder.Property(user => user.ProfilePictureUrl).HasMaxLength(2048);
            builder.Property(user => user.Weight).HasPrecision(6, 2);
            builder.Property(user => user.Height).HasPrecision(5, 2);
        }
    }
}
