using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class BicycleContext:DbContext
    {
        public BicycleContext(DbContextOptions<BicycleContext> options): base(options)
        {

        }

        public DbSet<Bicycle> Bicycles { get; set; }
    }
}
