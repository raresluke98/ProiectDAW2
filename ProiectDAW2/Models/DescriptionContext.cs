using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class DescriptionContext : DbContext
    {
        public DescriptionContext(DbContextOptions<DescriptionContext> options) : base(options)
        {

        }

        public DbSet<Description> Descriptions { get; set; }
    }
}
