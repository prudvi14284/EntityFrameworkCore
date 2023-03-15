using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasOne(a => a.StudentAddress)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(a => a.StudentId);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
