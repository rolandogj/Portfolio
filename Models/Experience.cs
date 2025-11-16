using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // null = actual
        public string Description { get; set; }

        // Relación con entidad Student Profile
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

    }
}