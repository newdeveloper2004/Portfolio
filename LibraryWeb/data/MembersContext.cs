using LibraryWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace LibraryWeb.data
{
    public class MembersContext : DbContext

    {
        public MembersContext(DbContextOptions<MembersContext> options) : base(options) 
        {
            
        
        }
        public DbSet<Members> Members { get; set; }   
    }

}
