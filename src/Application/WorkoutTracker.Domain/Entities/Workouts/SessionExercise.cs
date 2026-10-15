using WorkoutTracker.Domain.Common;

namespace WorkoutTracker.Domain.Entities.Workouts
{
    public class SessionExercise : BaseEntity
    {
        public int Order { get; set; }
        public TimeSpan? RestTime { get; set; }

        public Guid WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; } = null!;

        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; } = null!;

        public ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
    }
}
