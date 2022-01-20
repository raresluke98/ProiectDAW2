using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class CompetitionContext:DbContext
    {
        public CompetitionContext(DbContextOptions<CompetitionContext> options): base(options)
        {

        }

        public DbSet<Competition> Competitions { get; set; }
    }
}
