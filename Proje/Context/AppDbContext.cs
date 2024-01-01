using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Proje.Models;

namespace Proje.Context
{
    public class AppDbContext : DbContext
    {
        private static AppDbContext _instance;
        public static AppDbContext getInstance()
        {
            if (_instance == null)
                _instance = new AppDbContext();
            return _instance;
        }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Uzmanlik> Uzmanliks { get; set; }

        public DbSet<Doktor> Doktors  { get; set; }

        public DbSet<MesaiGunu> MesaiGunu { get; set; }
        public DbSet<Mesai> Mesai { get; set; }
        public DbSet<Randevu> Randevus { get; set; }

        
    }
}
