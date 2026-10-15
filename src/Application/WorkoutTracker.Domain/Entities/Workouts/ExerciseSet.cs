using WorkoutTracker.Domain.Common;

namespace WorkoutTracker.Domain.Entities.Workouts
{
    public class ExerciseSet : BaseEntity
    {
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public bool IsCompleted { get; set; }

        public Guid SessionExerciseId { get; set; }
        public SessionExercise SessionExercise { get; set; } = null!;
    }
}
