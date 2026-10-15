using WorkoutTracker.Domain.Common;

namespace WorkoutTracker.Domain.Entities.Workouts
{
    public class Exercise : BaseEntity
    {
        public string ExerciseName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<SessionExercise> SessionExercises { get; set; } = new List<SessionExercise>();
    }
}
