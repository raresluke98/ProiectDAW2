using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.ViewModels
{
    public class BicycleVM
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string FrameNumber { get; set; }

        public List<int> ServiceIds { get; set; }

        public List<int> CompetitionIds { get; set; }
    }
}
