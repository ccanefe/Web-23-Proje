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
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<AnaBilimDali> AnaBilimDali { get; set; }
        public DbSet<Poliklinikler> Poliklinikler { get; set; }
        public DbSet<CalismaZamani> CalismaZamani { get; set; }
        public DbSet<Randevu> Randevu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Doctors>()
                .HasOne(d => d.Poliklinikler)
                .WithMany()
                .HasForeignKey(d => d.PolikliniklerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
