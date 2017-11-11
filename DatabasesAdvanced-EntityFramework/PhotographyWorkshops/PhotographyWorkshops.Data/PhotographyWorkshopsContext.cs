namespace PhotographyWorkshops.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyWorkshopsContext : DbContext
    {
        public PhotographyWorkshopsContext()
            : base("name=PhotographyWorkshopsContext")
        {
        }

        public DbSet<Workshop> Workshops { get; set; }

        public DbSet<Camera> Cameras { get; set; }

        public DbSet<Photographer> Photographers { get; set; }

        public DbSet<Accessory> Accessories { get; set; }

        public DbSet<Lens> Lenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographer>()
                .HasRequired(cam => cam.PrimaryCamera)
                .WithOptional(camera => camera.Photographer)
                .WillCascadeOnDelete(false);
        }
    }

    
}