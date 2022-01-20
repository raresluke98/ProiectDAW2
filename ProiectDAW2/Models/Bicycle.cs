using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class Bicycle
    {
        [Key]
        public int BicycleId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Brand { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Model { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FrameNumber { get; set; }

        public Description Description { get; set; }

        public List<Service> Services { get; set; } = new List<Service>();

        public List<Competition> Competitions { get; set; } = new List<Competition>();
    }
}
