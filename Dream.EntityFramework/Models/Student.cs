using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dream.EntityFramework.Models
{
    public class Student
    {
        [MaxLength(40)]
        [Required]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstMidName { get; set; }
        [MaxLength(50)]
        [Required]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
