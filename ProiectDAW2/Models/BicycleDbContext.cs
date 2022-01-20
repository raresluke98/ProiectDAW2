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

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
