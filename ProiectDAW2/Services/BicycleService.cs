using ProiectDAW2.Models;
using ProiectDAW2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Services
{
    public class BicycleService
    {
        private BicycleDbContext _context;
        public BicycleService(BicycleDbContext context)
        {
            _context = context;
        }

        public void AddBicycle(BicycleVM bicycle)
        {
            var _bicycle = new Bicycle()
            {
                Brand = bicycle.Brand,
                Model = bicycle.Model,
                FrameNumber = bicycle.FrameNumber
            };
            _context.Bicycles.Add(_bicycle);
            _context.SaveChanges();
        }
    }
}
