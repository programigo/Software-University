namespace BikeMania.Data
{
    using BikeMania.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BikeManiaDbContext : IdentityDbContext<User>
    {
        public BikeManiaDbContext(DbContextOptions<BikeManiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<CartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Bikes)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder
                .Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);

            base.OnModelCreating(builder);
            
        }
    }
}
