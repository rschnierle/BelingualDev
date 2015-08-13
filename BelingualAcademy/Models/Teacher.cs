using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string StreetAddress { get; set; }

        public string Suburb { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public Gender Gender { get; set; }

        public string BirthPlace { get; set; }

        public string Comments { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}