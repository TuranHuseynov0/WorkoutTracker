using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class SessionExerciseConfiguration : BaseEntityConfiguration<SessionExercise>
    {
        public override void Configure(EntityTypeBuilder<SessionExercise> builder)
        {
            base.Configure(builder);
            builder.ToTable("SessionExercises", table =>
            {
                table.HasCheckConstraint("CK_SessionExercises_Order", "\"Order\" > 0");
                table.HasCheckConstraint("CK_SessionExercises_RestTime",
                    "\"RestTime\" IS NULL OR \"RestTime\" >= INTERVAL '0 seconds'");
            });

            builder.Property(exercise => exercise.RestTime).HasColumnType("interval");
            builder.HasIndex(exercise => new { exercise.WorkoutSessionId, exercise.Order }).IsUnique();

            builder.HasOne(exercise => exercise.WorkoutSession)
                .WithMany(workout => workout.SessionExercises)
                .HasForeignKey(exercise => exercise.WorkoutSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(exercise => exercise.Exercise)
                .WithMany(exercise => exercise.SessionExercises)
                .HasForeignKey(exercise => exercise.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
