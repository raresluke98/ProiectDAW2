using ProiectDAW2.Models;
using ProiectDAW2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Services
{
    public class DescriptionService
    {
        private BicycleDbContext _context;
        public DescriptionService(BicycleDbContext context)
        {
            _context = context;
        }

        public void AddDescription(DescriptionVM description)
        {
            var _description = new Description()
            {
                Owner = description.Owner,
                WheelSize = description.WheelSize,
                BicycleType = description.BicycleType,
                BicycleId = description.BicycleId
            };
            _context.Descriptions.Add(_description);
            _context.SaveChanges();
        }
    }
}
