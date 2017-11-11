﻿using Microsoft.EntityFrameworkCore;

public class StudentSystemDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Homework> Homeworks { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<License> Licenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=.;Database=StudentSystemDb;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder
            .Entity<Student>()
            .HasMany(s => s.Courses)
            .WithOne(c => c.Student)
            .HasForeignKey(c => c.StudentId);

        builder
            .Entity<Course>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Course)
            .HasForeignKey(s => s.CourseId);

        builder
            .Entity<Course>()
            .HasMany(c => c.Resources)
            .WithOne(r => r.Course)
            .HasForeignKey(r => r.CourseId);

        builder
            .Entity<Course>()
            .HasMany(c => c.Homeworks)
            .WithOne(h => h.Course)
            .HasForeignKey(c => c.CourseId);

        builder
            .Entity<Homework>()
            .HasOne(h => h.Student)
            .WithMany(s => s.Homeworks)
            .HasForeignKey(h => h.StudentId);

        builder
            .Entity<Resource>()
            .HasMany(r => r.Licenses)
            .WithOne(l => l.Resource)
            .HasForeignKey(r => r.ResourceId);
    }
}