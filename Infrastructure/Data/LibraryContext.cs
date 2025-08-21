using code_three.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace code_three.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { } //?
        public DbSet<Book> Books { get; set; }
    }
}