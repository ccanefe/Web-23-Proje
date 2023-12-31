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
        public DbSet<Uzmanlik> Uzmanlik { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Mesai> Mesai { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<MesaiGunu> MesaiGunu { get; set; }
    }
}
