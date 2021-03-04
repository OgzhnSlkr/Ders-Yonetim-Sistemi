using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using DersYonetimSistemi.Entities.Concrete;
using DersYonetimSistemi.Core.Abstract;
using DersYonetimSistemi.Entities.Concrete.AssociationEntities;

namespace DersYonetimSistemi.DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public AppDbContext()
        {
             
        }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserLesson> UsersLessons { get; set; }
        public DbSet<DaysOfLesson> DaysOfWeek { get; set; }
        public DbSet<LessonDay> LessonDays { get; set; }
        public DbSet<LessonDepartment> LessonDepartments { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<LessonMessage> LessonMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin", NormalizedName = "admin".ToUpper(), AddedDate = DateTime.Now });
            builder.Entity<Role>().HasData(new Role { Id = 2, Name = "Teacher", NormalizedName = "Teacher".ToUpper(), AddedDate = DateTime.Now });
            builder.Entity<Role>().HasData(new Role { Id = 3, Name = "Student", NormalizedName = "Student".ToUpper(), AddedDate = DateTime.Now });

            builder.Entity<UserLesson>()
                .HasKey(ul => new { ul.UserId, ul.LessonId });

            builder.Entity<UserLesson>()
                .HasOne(ul => ul.Lesson)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(ul => ul.LessonId);

            builder.Entity<UserLesson>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul => ul.UserId);

            builder.Entity<LessonDay>()
                .HasKey(ld => new { ld.DayId, ld.LessonId });

            builder.Entity<LessonDay>()
                .HasOne(ld => ld.Lesson)
                .WithMany(d => d.LessonDays)
                .HasForeignKey(ld => ld.LessonId);

            builder.Entity<LessonDay>()
                .HasOne(ld => ld.daysOfLesson)
                .WithMany(d => d.LessonDays)
                .HasForeignKey(ld => ld.DayId);

            builder.Entity<LessonDepartment>()
                .HasKey(ul => new { ul.LessonId, ul.DepartmentId });

            builder.Entity<LessonDepartment>()
                .HasOne(ld => ld.Department)
                .WithMany(d => d.LessonDepartments)
                .HasForeignKey(ld => ld.DepartmentId);

            builder.Entity<LessonDepartment>()
                .HasOne(ld => ld.Lesson)
                .WithMany(d => d.LessonDepartments)
                .HasForeignKey(ld => ld.LessonId);

            builder.Entity<UserMessage>()
                .HasKey(um => new { um.MessageId, um.UserId });

            builder.Entity<UserMessage>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(um => um.UserId);

            builder.Entity<UserMessage>()
                .HasOne(um => um.Message)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(um => um.MessageId);

            builder.Entity<LessonMessage>()
                .HasKey(lm => new { lm.MessageId, lm.LessonId });

            builder.Entity<LessonMessage>()
                .HasOne(lm => lm.Lesson)
                .WithMany(l => l.LessonMessages)
                .HasForeignKey(lm => lm.LessonId);

            builder.Entity<LessonMessage>()
                .HasOne(lm => lm.Message)
                .WithMany(l => l.LessonMessages)
                .HasForeignKey(lm => lm.MessageId);
        }

    }
}
