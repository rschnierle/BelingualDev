using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BelingualAcademy.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Phone]
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

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}