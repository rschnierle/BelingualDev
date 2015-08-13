using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class Class
    {
        public int ClassID { get; set; }

        public int GroupID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ClassRoomID { get; set; }


        public virtual Group Group { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
    }
}