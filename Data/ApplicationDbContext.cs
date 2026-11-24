using Microsoft.EntityFrameworkCore;
using InstructorInformationsSystem.Models;

namespace InstructorInformationsSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.InstructorID);
        }
    }
}