using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class Group
    {
        public int GroupID { get; set; }

        public int CourseID { get; set; }

        public int TeacherID { get; set; }

        public string Period { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Class> Clases { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}