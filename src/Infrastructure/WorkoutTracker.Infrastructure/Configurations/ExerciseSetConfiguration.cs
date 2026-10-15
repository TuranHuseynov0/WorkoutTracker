using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class ExerciseSetConfiguration : BaseEntityConfiguration<ExerciseSet>
    {
        public override void Configure(EntityTypeBuilder<ExerciseSet> builder)
        {
            base.Configure(builder);
            builder.ToTable("ExerciseSets", table =>
            {
                table.HasCheckConstraint("CK_ExerciseSets_SetNumber", "\"SetNumber\" > 0");
                table.HasCheckConstraint("CK_ExerciseSets_Reps", "\"Reps\" >= 0");
                table.HasCheckConstraint("CK_ExerciseSets_Weight", "\"Weight\" >= 0");
            });

            builder.Property(set => set.Weight).HasPrecision(7, 2);
            builder.HasIndex(set => new { set.SessionExerciseId, set.SetNumber }).IsUnique();

            builder.HasOne(set => set.SessionExercise)
                .WithMany(exercise => exercise.ExerciseSets)
                .HasForeignKey(set => set.SessionExerciseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
