using ProiectDAW2.Models;
using ProiectDAW2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Services
{
    public class CompetitionService
    {
        private BicycleDbContext _context;
        public CompetitionService(BicycleDbContext context)
        {
            _context = context;
        }

        public void AddCompetition(CompetitionVM competition)
        {
            var _competition = new Competition()
            {
                CompetitionName = competition.CompetitionName,
                Location = competition.Location,
                Terrain = competition.Terrain,
                Length = competition.Length
            };
            _context.Competitions.Add(_competition);
            _context.SaveChanges();
        }
    }
}
