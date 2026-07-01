using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace University_System_Models.Models
{
    [Index(nameof(Email), IsUnique = true)]  // put it outside the class
    internal class Instructor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //i need this because the value is created automatically by the database/system, not entered by the user.
        public int InstructorId { get; set; }  // system generated
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }  // user input
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }  // user input
        [MaxLength(20)]
        public string OfficeNumber { get; set; }  // user input
        [Required]
        public DateTime HireDate { get; set; }  // System generated (because we will use (date.now)method)
        [Required]
        [Range(0.01, double.MaxValue)]  // to be more than 0
        public decimal Salary { get; set; }  // Calculated
        [Required]
        [MaxLength(50)]
        public string AcademicTitle { get; set; }  // user input
        public Department Department { get; set; } // Navigation property // like connect both 

        public ICollection<Course> Courses { get; set; } // Navigation property  // for many courses
    }
}
