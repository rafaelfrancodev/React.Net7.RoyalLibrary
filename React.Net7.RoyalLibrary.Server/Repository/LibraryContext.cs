using Microsoft.EntityFrameworkCore;
using React.Net7.RoyalLibrary.Server.Models;

namespace React.Net7.RoyalLibrary.Server.Repository
{

    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("books");
        }
    }
}
