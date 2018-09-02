using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
                    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
