using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.NewFolder
{
    public class Tunify_DbContext : DbContext
    {
        public Tunify_DbContext(DbContextOptions options) : base(options) 
        {
               
        }
        public DbSet<Users> users { get; set; }
    }
}
