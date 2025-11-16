using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class SocialLink
    {
        public int Id { get; set; }
        public string Platform { get; set; }  // ejemplo: LinkedIn, GitHub
        public string Url { get; set; }

        // Relación con entidad Student Profile
        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; }

    }
}