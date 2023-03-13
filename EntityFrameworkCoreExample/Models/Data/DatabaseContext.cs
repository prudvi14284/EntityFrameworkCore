using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options) : base(options)
        {
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
