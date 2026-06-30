using Microsoft.EntityFrameworkCore;   // i need to install it to work for me the unique
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace University_System_Models.Models
{



    [Index(nameof(Email), IsUnique = true)]  // put it outside the class
    internal class Student
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //i need this because the value is created automatically by the database/system, not entered by the user.
        public int StudentId { get; set; }  // system generated
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }  // user input
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }  // user input
        [MaxLength(20)]
        public string PhoneNumber { get; set; }  // user input
        [Required]
        public DateTime DateOfBirth { get; set; }  // Calculated 
        [Required]
        [Range (2000, 2030) ]
        public int EnrollmentYear { get; set; }  // user input
        [Range(0.0, 4.0)]
        public decimal Gpa { get; set; } = 0.0m; //as default = 0.0  // m = decimal type

        public ICollection<Course> Courses { get; set; } // Navigation property  // many courses

        public ICollection<Enrollment> Enrollments { get; set; } // Navigation property  // many Enrollments
    }
}
