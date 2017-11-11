using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder buider)
    {
        buider.UseSqlServer(@"Server=.;Database=TestDb;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Employee>()
            .HasOne(em => em.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);

        builder
            .Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(m => m.Employees)
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}