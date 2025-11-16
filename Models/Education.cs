using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string Degrre { get; set; } // ejemplo: Ingeniaria en Sistemas
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // null = en curso

        // Relación con entidad Student Profile
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

    }
}