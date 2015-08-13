using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int GroupID { get; set; }
        public int StudentID { get; set; }
        public string Grade { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}