using Microsoft.EntityFrameworkCore;
using Proje.Models;

namespace Proje.Context
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        
    }
}
