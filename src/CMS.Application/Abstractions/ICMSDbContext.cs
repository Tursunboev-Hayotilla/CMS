using CMS.Domain.Entities;
using CMS.Domain.Entities.Auth;
using CMS.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Abstractions
{
    public interface ICMSDbContext
    {
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
        public DbSet<User> Users { get; set; }
        public DbSet<StudentAppraciate> StudentAppraciates { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<ExamAppraciateStudent> ExamAppraciates { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
