using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgressTracker.Models;

namespace ProgressTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //dbsets for each table that can do CRUD
        public DbSet<ProgressTracker.Models.Movement> Movements { get; set; } = default!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovementItem> MovementItems { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }

    }
}