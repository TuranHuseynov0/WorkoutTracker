using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class WorkoutSessionConfiguration : BaseEntityConfiguration<WorkoutSession>
    {
        public override void Configure(EntityTypeBuilder<WorkoutSession> builder)
        {
            base.Configure(builder);
            builder.ToTable("WorkoutSessions", table =>
                table.HasCheckConstraint("CK_WorkoutSessions_CompletedAt",
                    "\"CompletedAt\" IS NULL OR \"CompletedAt\" >= \"StartedAt\""));

            builder.Property(workout => workout.Name).IsRequired().HasMaxLength(200);
            builder.Property(workout => workout.Notes).HasMaxLength(2000);
            builder.Property(workout => workout.StartedAt).IsRequired();
            builder.HasIndex(workout => new { workout.AppUserId, workout.StartedAt });

            builder.HasOne(workout => workout.AppUser)
                .WithMany(user => user.WorkoutSessions)
                .HasForeignKey(workout => workout.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
