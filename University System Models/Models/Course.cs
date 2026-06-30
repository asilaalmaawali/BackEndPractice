using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace University_System_Models.Models
{
    [Index(nameof(CourseCode), IsUnique = true)]  //should be outside the class
    internal class Course
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //i need this because the value is created automatically by the database/system, not entered by the user.
        public int CourseId { get; set; }  // system generated
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]{2,4}[0-9]{3}$", ErrorMessage = "Course code must be like CS101.")]  // ^start text,  2 to 4 capital letters , exactly 3 numbers , $ end the text
        public string CourseCode { get; set; }  // system generated
        [Required]
        [MaxLength(150)]
        public string CourseTitle { get; set; }  // user input
        [Required]
        [Range(1, 6)]
        public int CreditHours { get; set; }  // user input
        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }  //from list // foreign key from Department class
        public Department Department { get; set; } // Navigation property 

        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }   //from list // foreign key from Instructor class // int? (can be null) becuase (a course may be unassigned)
        public Instructor Instructor { get; set; } // Navigation property (for one)
        [Required]
        [MaxLength(20)]
        public string SemesterOffered { get; set; }  // user input

        public ICollection<Student> Students { get; set; } // Navigation property  // many students

    }
}
