using Microsoft.AspNetCore.Identity;
using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Domain.Entities.Auth
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }

        public string? Bio { get; set; }
        public string? SocialMediaLinks { get; set; }
        
        public DateOnly BirthDate { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        
        public int WorkoutCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }

        public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}
