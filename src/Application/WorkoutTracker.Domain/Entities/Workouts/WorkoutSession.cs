using WorkoutTracker.Domain.Common;
using WorkoutTracker.Domain.Entities.Auth;

namespace WorkoutTracker.Domain.Entities.Workouts
{
    public class WorkoutSession : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public ICollection<SessionExercise> SessionExercises { get; set; } = new List<SessionExercise>();
    }
}
