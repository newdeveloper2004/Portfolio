using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWeb.data
{
    public class LentBooksContext : DbContext
    {
        public LentBooksContext(DbContextOptions<LentBooksContext> options) : base(options) { 
        }

        public DbSet<LentBooks>lent_books { get; set; }
    }
}
