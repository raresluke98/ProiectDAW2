using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Models
{
    public class Competition
    {
        [Key]
        public int CompetitionId { get; set; }

        // YYYY-MM-DD
        [Column(TypeName = "nvarchar(50)")]
        public string CompetitionName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Location { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Terrain { get; set; }

        [Column(TypeName = "int")]
        public int Length { get; set; }

        // public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
