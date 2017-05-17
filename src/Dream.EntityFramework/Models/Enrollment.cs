using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dream.EntityFramework.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        [MaxLength(40)]
        [Required]
        public int EnrollmentID { get; set; }
        [MaxLength(40)]
        [Required]
        public int CourseID { get; set; }
        [MaxLength(40)]
        [Required]
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
