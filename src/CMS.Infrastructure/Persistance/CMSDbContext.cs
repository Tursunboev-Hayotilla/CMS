using CMS.Application.Abstractions;
using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Persistance
{
    public class CMSDbContext : IdentityDbContext<User>, ICMSDbContext
    {
        public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        {
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Examine> Examines { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Subjects)
                .WithOne(s => s.Class)
                .HasForeignKey(s => s.ClassId);
            modelBuilder.Entity<Attendance>()
              .HasOne(a => a.Lesson)
              .WithOne(l => l.Attendance)
              .HasForeignKey<Lesson>(l => l.AttendanceId);
        }
    }
}
