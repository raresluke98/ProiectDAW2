using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class BicycleDbContext:DbContext
    {
             
        public BicycleDbContext(DbContextOptions<BicycleDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(b => b.Bicycle)
                .WithMany(a => a.Appointments)
                .HasForeignKey(bi => bi.BicycleId);

            modelBuilder.Entity<Appointment>()
                .HasOne(c => c.Competition)
                .WithMany(a => a.Appointments)
                .HasForeignKey(ci => ci.CompetitionId);

            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
