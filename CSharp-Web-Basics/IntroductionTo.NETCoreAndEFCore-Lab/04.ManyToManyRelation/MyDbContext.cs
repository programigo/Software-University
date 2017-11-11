using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=.;Database=StudentsDb;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<StudentsCourses>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

        builder
            .Entity<Student>()
            .HasMany(st => st.Courses)
            .WithOne(sc => sc.Student)
            .HasForeignKey(sc => sc.StudentId);

        builder
            .Entity<Course>()
            .HasMany(c => c.Students)
            .WithOne(sc => sc.Course)
            .HasForeignKey(sc => sc.CourseId);
    }
}