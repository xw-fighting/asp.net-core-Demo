using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dream.EntityFramework.Models;

namespace Dream.Web.Api.Models
{
    public class StudentDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "长度不能大于5", MinimumLength = 2)]
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
