using Artists_Reviews.Models;
using Microsoft.EntityFrameworkCore;

namespace Artists_Reviews.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the ID property to not auto-generate values
            modelBuilder.Entity<Artist>()
                .Property(b => b.Id)
                .ValueGeneratedNever(); // Disable identity generation for DeezerID
        }
    }
}
