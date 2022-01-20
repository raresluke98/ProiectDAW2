using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Owner { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string WheelSize { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BicycleType { get; set; }

        [ForeignKey("Bicycle")]
        public int BicycleId { get; set; }
        // public Bicycle Bicycle { get; set; }
    }
}
