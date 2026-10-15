using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities.Auth;
using WorkoutTracker.Domain.Entities.Workouts;

namespace WorkoutTracker.Infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<WorkoutSession> WorkoutSessions => Set<WorkoutSession>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<SessionExercise> SessionExercises => Set<SessionExercise>();
        public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
