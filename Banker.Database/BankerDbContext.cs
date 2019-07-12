
using Microsoft.EntityFrameworkCore;
using System;

namespace Banker.Database
{
    public class BankerDbContext : DbContext
    {
        public BankerDbContext(DbContextOptions<BankerDbContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
