using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; } // ejemplo: C#, Python, trabajar en exquipo
        public int Level { get; set; }  // 1-100

        // Relación con entidad Student Profile
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

    }
}