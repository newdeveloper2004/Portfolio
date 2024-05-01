using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWeb.data
{
    public class UsersContext :DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options ) :base(options) { }
        public DbSet<Users> users { get; set; }
    }
   
}
