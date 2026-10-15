using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Infrastructure.Configurations
{
    public class ExerciseConfiguration : BaseEntityConfiguration<Exercise>
    {
        public override void Configure(EntityTypeBuilder<Exercise> builder)
        {
            base.Configure(builder);
            builder.ToTable("Exercises");
            builder.Property(exercise => exercise.ExerciseName).IsRequired().HasMaxLength(200);
            builder.Property(exercise => exercise.Description).HasMaxLength(2000);
            builder.Property(exercise => exercise.ImageUrl).HasMaxLength(2048);
            builder.HasIndex(exercise => exercise.ExerciseName);
        }
    }
}
