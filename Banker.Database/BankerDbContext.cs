
using Microsoft.EntityFrameworkCore;

namespace Banker.Database
{
    public class BankerDbContext : DbContext
    {
        public BankerDbContext(DbContextOptions<BankerDbContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("User");
                user.HasKey("UserId");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
