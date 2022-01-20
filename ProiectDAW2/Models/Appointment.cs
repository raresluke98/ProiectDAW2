using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Bicycle")]
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
