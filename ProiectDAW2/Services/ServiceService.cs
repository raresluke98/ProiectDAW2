using ProiectDAW2.Models;
using ProiectDAW2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Services
{
    public class ServiceService
    {
        private BicycleDbContext _context;
        public ServiceService(BicycleDbContext context)
        {
            _context = context;
        }

        public void AddService(ServiceVM service)
        {
            var _service = new Service()
            {
                AppointmentDate = service.AppointmentDate,
                Operation = service.Operation,
                Cost = service.Cost
            };
            _context.Services.Add(_service);
            _context.SaveChanges();
        }
    }
}
