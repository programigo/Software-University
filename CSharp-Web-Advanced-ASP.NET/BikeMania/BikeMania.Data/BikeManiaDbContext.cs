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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Bikes)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            base.OnModelCreating(builder);
            
        }
    }
}
