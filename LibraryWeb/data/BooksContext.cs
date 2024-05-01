using Microsoft.EntityFrameworkCore;
using LibraryWeb.Models;
namespace LibraryWeb.data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }
        public DbSet<Books> books { get; set; }
    }
}
