using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace University_System_Models.Models
{
    internal class Enrollment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //i need this because the value is created automatically by the database/system, not entered by the user.
        public int EnrollmentId { get; set; }  // system generated
        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }  //from list // foreign key from Student class
        public Student Student { get; set; } // navigation property
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }  //from list // foreign key from Course class
        public Course Course { get; set; } // navigation property
        [Required]
        public DateTime EnrollmentDate { get; set; } // System generated (because we will use (date.now)method)
        [MaxLength(2)]
        public string? FinalGrade { get; set; } // user input  // can be null 
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "In Progress";// as default "In Progress"
    }
}
