using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Salesman> Salesmen { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=.;Database=MyTestShop;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Customer>()
            .HasOne(c => c.Salesman)
            .WithMany(s => s.Customers)
            .HasForeignKey(s => s.SalesmenId);

        builder
            .Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(c => c.CustomerId);

        builder
            .Entity<Customer>()
            .HasMany(c => c.Reviews)
            .WithOne(o => o.Customer)
            .HasForeignKey(c => c.CustomerId);

        builder
            .Entity<ItemOrder>()
            .HasKey(io => new { io.ItemId, io.OrderId });

        builder
            .Entity<Item>()
            .HasMany(i => i.Orders)
            .WithOne(io => io.Item)
            .HasForeignKey(io => io.ItemId);

        builder
            .Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(io => io.Order)
            .HasForeignKey(io => io.OrderId);

        builder
            .Entity<Item>()
            .HasMany(i => i.Reviews)
            .WithOne(r => r.Item)
            .HasForeignKey(r => r.ItemId);
    }
}