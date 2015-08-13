using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class ClassRoom
    {
        public int ClassRoomID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Class> Clases { get; set; }
    }
}