using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        // YYYY-MM-DD
        [Column(TypeName = "nvarchar(10)")]
        public string AppointmentDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Operation { get; set; }

        [Column(TypeName = "int")]
        public string Cost { get; set; }

        [ForeignKey("Bicycle")]
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
    }
}
